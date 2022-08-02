using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.RecipeModels;
using Microsoft.EntityFrameworkCore;

namespace CookingByMe_back.Core.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(CookingByMeContext context) : base(context)
        {
        }

        public async Task<List<Recipe>> GetAllRecipesAsync(string userId)
        {
            //return await FindAll().Include(r => r.Group_Recipe).ToListAsync();
            return await FindAll().Where(r => r.UserId == userId).AsNoTracking().ToListAsync();
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            var currentRecipe = await FindByCondition(r => r.Id.Equals(id))
                .Include(r => r.StepsList!.OrderBy(s => s.Order))
                .Include(r => r.IngredientsList)
                .Include(r => r.Group_Recipe!)
                .OrderByDescending(r => r.CreatedAt)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return currentRecipe;
        }


        public void CreateIngredient(Recipe recipe, Ingredient ingredient)
        {
            recipe.IngredientsList!.Add(ingredient);
        }

        public void CreateRecipe(Recipe recipe)
        {
            Create(recipe);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            recipe.UpdatedAt = DateTime.Now;
            Update(recipe);
        }

        public void DeleteRecipe(Recipe recipe)
        {
            Delete(recipe);
        }
    }
}
