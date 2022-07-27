using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.RecipeModels;

namespace CookingByMe_back.Core.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(CookingByMeContext context) : base(context)
        {
        }

        public void CreateRecipe(Recipe recipe)
        {
            Create(recipe);
        }
        public Task<List<Recipe>> getAllByGroupIdAsync(int groupId)
        {
            return Task.FromResult(new List<Recipe>());
        }
    }
}
