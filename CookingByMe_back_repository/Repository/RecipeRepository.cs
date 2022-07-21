using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.Recipe;

namespace CookingByMe_back.Core.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public Task<List<Recipe>> getAllByGroupIdAsync(int groupId)
        {
            return Task.FromResult(new List<Recipe>());
        }
    }
}
