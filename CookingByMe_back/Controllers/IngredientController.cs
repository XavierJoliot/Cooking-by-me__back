using AutoMapper;
using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.IngredientModels;
using Microsoft.AspNetCore.Mvc;

namespace CookingByMe_back.Controllers
{
    [ApiController]
    [Route("api/ingredient")]
    public class IngredientController : ControllerBase
    {
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientController(IMapper mapper, IIngredientRepository ingredientRepository)
        {
            _mapper = mapper;
            _ingredientRepository = ingredientRepository;
            //_logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredientByIdAsync(int id)
        {
            var ingredient = await _ingredientRepository.GetIngredientByIdAsync(id);
            //_logger.LogInfo($"Returned a step from database.");
            var ingredientResult = _mapper.Map<Ingredient>(ingredient);
            if (ingredientResult == null)
            {
                return NotFound();
            }

            return Ok(ingredientResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientAsync(int id)
        {
            try
            {
                var ingredient = await _ingredientRepository.GetIngredientByIdAsync(id);
                if (ingredient == null)
                {
                    //_logger.LogError($"Ingredient with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _ingredientRepository.DeleteIngredient(ingredient);
                await _ingredientRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside DeleteIngredient action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredientpAsync(int id, IngredientForUpdateDto ingredient)
        {
            try
            {
                if (ingredient == null)
                {
                    //_logger.LogError("ingredient object sent from client is null.");
                    return BadRequest("Ingredient object is null");
                }

                if (!ModelState.IsValid)
                {
                    //_logger.LogError("Invalid ingredient object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var ingredientEntity = await _ingredientRepository.GetIngredientByIdAsync(id);

                _mapper.Map(ingredient, ingredientEntity);

                if (ingredientEntity == null)
                {
                    //_logger.LogError($"ingredient with id: {id}, hasn't been found in db.");
                    return NotFound();
                }


                _ingredientRepository.UpdateIngredient(ingredientEntity);
                await _ingredientRepository.SaveAsync();

                return Ok(ingredientEntity);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateIngredientAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
