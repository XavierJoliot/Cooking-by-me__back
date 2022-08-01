using AutoMapper;
using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.RecipeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookingByMe_back.Controllers
{
    [ApiController]
    [Authorize]
    [EnableCors]
    [Route("api/recette")]
    public class RecipeController : ControllerBase
    {
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IStepRepository _stepRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IGroupRepository _groupRepository;

        public RecipeController(
            IMapper mapper, 
            IRecipeRepository recipeRepository,
            IStepRepository stepRepository,
            IIngredientRepository ingredientRepository,
            IGroupRepository groupRepository)
        {
            _mapper = mapper;
            _recipeRepository = recipeRepository;
            _stepRepository = stepRepository;
            _ingredientRepository = ingredientRepository;
            _groupRepository = groupRepository;
            //_logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipesAsync()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var recipesList = await _recipeRepository.GetAllRecipesAsync(userId);
            //_logger.LogInfo($"Returned all recipes from database.");
            var recipesResult = _mapper.Map<List<Recipe>>(recipesList);
            return Ok(recipesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeByIdAsync(int id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            //_logger.LogInfo($"Returned a recipe from database.");
            var recipeResult = _mapper.Map<Recipe>(recipe);
            if(recipeResult == null)
            {
                return NotFound();
            }

            return Ok(recipeResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipeAsync([FromBody] RecipeForCreationDto recipeForCreation)
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

                _recipeRepository.CreateRecipe(recipeEntity);

                await _recipeRepository.SaveAsync();

                var createdRecipe = _mapper.Map<Recipe, RecipeDto>(recipeEntity);

                return Ok(createdRecipe);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside RecipeForCreation action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

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
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside DeleteRecipe action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipeAsync(int id, RecipeForUpdateDto recipe)
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

                _mapper.Map(recipe, recipeEntity);

                if (recipeEntity == null)
                {
                    //_logger.LogError($"Recipe with id: {id}, hasn't been found in db.");
                    return NotFound();
                }


                _recipeRepository.UpdateRecipe(recipeEntity);
                await _recipeRepository.SaveAsync();

                return Ok(recipeEntity);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateRecipeAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
