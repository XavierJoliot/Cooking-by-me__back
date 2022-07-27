using AutoMapper;
using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.RecipeModels;
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

        public RecipeController(IMapper mapper, IRecipeRepository recipeRepository)
        {
            _mapper = mapper;
            _recipeRepository = recipeRepository;
            //_logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipeAsync(RecipeForCreationDto recipeForCreation)
        {
            try
            {
                if (recipeForCreation == null)
                {
                    //_logger.LogError("StepForCreation object sent from client is null.");
                    return BadRequest("StepForCreation object is null");
                }
                if (!ModelState.IsValid)
                {
                    //_logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var recipeEntity = _mapper.Map<RecipeForCreationDto, Recipe>(recipeForCreation);
                _recipeRepository.CreateRecipe(recipeEntity);
                await _recipeRepository.SaveAsync();
                var createdRecipe = _mapper.Map<Recipe, RecipeDto>(recipeEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside CreateStep action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
