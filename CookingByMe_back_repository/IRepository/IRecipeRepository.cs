using CookingByMe_back.Models.Recipe;

namespace CookingByMe_back.Core.IRepository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        public Task<List<Recipe>> getAllByGroupIdAsync(int groupId);
    }
}
