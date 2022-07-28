using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.RecipeModels;
using CookingByMe_back.Models.StepModels;

namespace CookingByMe_back.Core.IRepository
{
    public interface IRecipeRepository : IRepository<Recipe> 
    {
        public Task<List<Recipe>> GetAllRecipesAsync();

        public Task<Recipe?> GetRecipeByIdAsync(int id);

        public Task<Recipe?> FindRecipeAsync(int id);

        public void CreateStep(Recipe recipe, Step step);

        public void CreateIngredient(Recipe recipe, Ingredient ingredient);

        public void CreateRecipe(Recipe recipe);

        public void UpdateRecipe(Recipe recipe);

        public void DeleteRecipe(Recipe recipe);
    }
}
