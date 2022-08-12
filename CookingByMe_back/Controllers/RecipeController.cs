using AutoMapper;
using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.GroupRecipeModels;
using CookingByMe_back.Models.RecipeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookingByMe_back.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("api/recette")]
    public class RecipeController : MainController
    {
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(
            IMapper mapper, 
            IRecipeRepository recipeRepository)
        {
            _mapper = mapper;
            _recipeRepository = recipeRepository;
            //_logger = logger;
        }

        [HttpGet("cooking-by-me")]
        public async Task<IActionResult> GetAllCookingRecipesAsync()
        {
            var recipesList = await _recipeRepository.GetAllCookingRecipesAsync();
            //_logger.LogInfo($"Returned all recipes from database.");
            var recipesResult = _mapper.Map<List<Recipe>>(recipesList);
            return Ok(recipesResult);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllRecipesAsync()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var recipesList = await _recipeRepository.GetAllRecipesAsync(userId);
            //_logger.LogInfo($"Returned all recipes from database.");
            var recipesResult = _mapper.Map<List<Recipe>>(recipesList);
            return Ok(recipesResult);
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeByIdAsync(int id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            //_logger.LogInfo($"Returned a recipe from database.");
            if(recipe == null)
            {
                return NotFound();
            }

            RecipeDto currentRecipe = _mapper.Map<Recipe, RecipeDto>(recipe);

            return Ok(currentRecipe);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRecipeAsync([FromForm] RecipeForCreationDto recipeForCreation)
        {
            try
            {
                if (recipeForCreation == null)
                {
                    //_logger.LogError("RecipeForCreation object sent from client is null.");
                    return BadRequest("StepForCreation object is null");
                }
                if (!ModelState.IsValid)
                {
                    //_logger.LogError("Invalid RecipeForCreation object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

                // Add recipe methods
                var recipeEntity = _mapper.Map<RecipeForCreationDto, Recipe>(recipeForCreation);

                recipeEntity.UserId = userId;

                if(recipeForCreation.ImagePath != null)
                {
                    AddImage(recipeForCreation.ImagePath);
                    recipeEntity.ImagePath = recipeForCreation.ImagePath.FileName;
                }

                _recipeRepository.CreateRecipe(recipeEntity);

                await _recipeRepository.SaveAsync();

                var createdRecipe = _mapper.Map<Recipe, RecipeDto>(recipeEntity);

                return Ok(createdRecipe);
            }
            catch (Exception)
            {
                //_logger.LogError($"Something went wrong inside RecipeForCreation action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeAsync(int id)
        {
            try
            {
                var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
                if (recipe == null)
                {
                    //_logger.LogError($"Recipe with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _recipeRepository.DeleteRecipe(recipe);
                await _recipeRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception)
            {
                //_logger.LogError($"Something went wrong inside DeleteRecipe action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipeAsync(int id, [FromForm] RecipeForUpdateDto recipe)
        {
            try
            {
                if (recipe == null)
                {
                    //_logger.LogError("recipe object sent from client is null.");
                    return BadRequest("Recipe object is null");
                }

                if (!ModelState.IsValid)
                {
                    //_logger.LogError("Invalid recipe object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var recipeEntity = await _recipeRepository.GetRecipeByIdAsync(id);

                string? currentImage = recipeEntity!.ImagePath;

                _mapper.Map(recipe, recipeEntity);

                if (recipeEntity == null)
                {
                    //_logger.LogError($"Recipe with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (recipe.ImagePath != null && recipe.ImagePath.FileName != currentImage)
                {
                    AddImage(recipe.ImagePath);
                    recipeEntity.ImagePath = recipe.ImagePath.FileName;
                } else
                {
                    recipeEntity.ImagePath = currentImage;
                }

                if (recipe.GroupIds != null)
                {
                    foreach (var groupId in recipe.GroupIds!)
                    {
                        if(recipeEntity.Group_Recipe!.Find(elmt => elmt.GroupId == groupId) == null) {
                            Group_Recipe groupRecipe = new Group_Recipe()
                            {
                                RecipeId = recipeEntity.Id,
                                GroupId = groupId,
                            };

                            recipeEntity.Group_Recipe!.Add(groupRecipe);
                            await _recipeRepository.SaveAsync();
                        }
                    }
                }


                _recipeRepository.UpdateRecipe(recipeEntity);
                await _recipeRepository.SaveAsync();

                return Ok(recipeEntity);
            }
            catch (Exception)
            {
                //_logger.LogError($"Something went wrong inside UpdateRecipeAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
