using AutoMapper;
using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.GroupRecipeModels;
using CookingByMe_back.Models.RecipeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CookingByMe_back.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("api/groupe-recette")]
    public class GroupRecipeController : MainController
    {
        private readonly IGroupRecipeRepository _groupRecipeRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public GroupRecipeController(IGroupRecipeRepository groupRecipeRepository, IRecipeRepository recipeRepository, IMapper mapper)
        {
            _groupRecipeRepository = groupRecipeRepository;
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("recette/{id}")]
        public async Task<IActionResult> AddGroupToRecipeAsync(int id, [FromBody] Group_RecipeForCreationFromRecipeDto groupRecipeForCreation)
        {
            try
            {
                if (groupRecipeForCreation == null)
                {
                    //_logger.LogError("RecipeForCreation object sent from client is null.");
                    return BadRequest("StepForCreation object is null");
                }
                if (!ModelState.IsValid)
                {
                    //_logger.LogError("Invalid RecipeForCreation object sent from client.");
                    return BadRequest("Invalid model object");
                }

                Recipe? currentRecipe = await _recipeRepository.GetRecipeByIdAsync(id);

                if(currentRecipe == null)
                {
                    return NotFound();
                }

                foreach(var groupId in groupRecipeForCreation.GroupIds!)
                {
                    if(currentRecipe.Group_Recipe!.Find(gr => gr.GroupId == groupId) == null)
                    {
                        Group_Recipe groupRecipe = new Group_Recipe()
                        {
                            RecipeId = currentRecipe.Id,
                            GroupId = groupId,
                        };

                        _groupRecipeRepository.CreateGroupRecipe(groupRecipe);
                        await _groupRecipeRepository.SaveAsync();
                    }
                }

                return Ok();
            }
            catch (Exception)
            {
                //_logger.LogError($"Something went wrong inside RecipeForCreation action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupInRecipeAsync(int id)
        {
            try
            {
                var groupRecipe = await _groupRecipeRepository.GetGroupRecipeByIdAsync(id);
                if (groupRecipe == null)
                {
                    //_logger.LogError($"GroupRecipe with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _groupRecipeRepository.DeleteGroupRecipe(groupRecipe);
                await _groupRecipeRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception)
            {
                //_logger.LogError($"Something went wrong inside DeleteGroupRecipe action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
