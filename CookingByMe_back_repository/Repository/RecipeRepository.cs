using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.RecipeModels;
using Microsoft.EntityFrameworkCore;

namespace CookingByMe_back.Core.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(CookingByMeContext context) : base(context)
        {
        }

        public async Task<List<Recipe>> GetAllRecipesAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            return await FindByCondition(r => r.Id.Equals(id))
                .Include(r => r.StepsList)
                .Include(r => r.IngredientsList)
                .FirstOrDefaultAsync();
        }

        public void CreateRecipe(Recipe recipe)
        {
            Create(recipe);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            Update(recipe);
        }

        public void DeleteRecipe(Recipe recipe)
        {
            Delete(recipe);
        }
    }
}
