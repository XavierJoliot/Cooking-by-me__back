using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.Ingredient;

namespace CookingByMe_back.Core.Repository
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public Task<List<Ingredient>> getAllByRecipeIdAsync(int recipeId)
        {
            return Task.FromResult(new List<Ingredient>());
        }
    }
}
