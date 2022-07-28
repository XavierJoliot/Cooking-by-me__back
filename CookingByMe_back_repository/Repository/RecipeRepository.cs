using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.RecipeModels;
using CookingByMe_back.Models.StepModels;
using Microsoft.EntityFrameworkCore;

namespace CookingByMe_back.Core.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private readonly CookingByMeContext context;
        public RecipeRepository(CookingByMeContext context) : base(context)
        {
            this.context = context;
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

        public async Task<Recipe?> FindRecipeAsync(int id)
        {
            return await FindEntityAsync(id);
        }

        public void CreateStep(Recipe recipe, Step step)
        {
            recipe!.StepsList.Add(step);
        }

        public void CreateIngredient(Recipe recipe, Ingredient ingredient)
        {
            recipe!.IngredientsList.Add(ingredient);
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
