using CookingByMe_back.Core.IRepository;
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

        public GroupRecipeController(IGroupRecipeRepository groupRecipeRepository)
        {
            _groupRecipeRepository = groupRecipeRepository;
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
