﻿using AutoMapper;
using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.GroupRecipeModels;
using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.RecipeModels;
using CookingByMe_back.Models.StepModels;
using Microsoft.AspNetCore.Mvc;

namespace CookingByMe_back.Controllers
{
    [ApiController]
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
            var recipesList = await _recipeRepository.GetAllRecipesAsync();
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
        public async Task<IActionResult> CreateRecipeAsync(RecipeForCreationDto recipeForCreation)
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

                // Add recipe methods
                var recipeEntity = _mapper.Map<RecipeForCreationDto, Recipe>(recipeForCreation);

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
