using CookingByMe_back.Models.RecipeModels;

namespace CookingByMe_back.Core.IRepository
{
    public interface IRecipeRepository : IRepository<Recipe> 
    {
        public Task<List<Recipe>> GetAllRecipesAsync();

        public Task<Recipe?> GetRecipeByIdAsync(int id);

        public void CreateRecipe(Recipe recipe);

        public void UpdateRecipe(Recipe recipe);

        public void DeleteRecipe(Recipe recipe);
    }
}
