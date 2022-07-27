using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.IngredientModels;

namespace CookingByMe_back.Core.Repository
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(CookingByMeContext context) : base(context)
        {
        }

        public Task<List<Ingredient>> getAllByRecipeIdAsync(int recipeId)
        {
            return Task.FromResult(new List<Ingredient>());
        }
    }
}
