using CookingByMe_back.Models.RecipeModels;

namespace CookingByMe_back.Core.IRepository
{
    public interface IRecipeRepository : IRepository<Recipe> 
    {
        public void CreateRecipe(Recipe recipe);
        public Task<List<Recipe>> getAllByGroupIdAsync(int groupId);
    }
}
