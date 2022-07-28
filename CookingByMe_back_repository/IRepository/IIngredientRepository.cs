using CookingByMe_back.Models.IngredientModels;

namespace CookingByMe_back.Core.IRepository
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        public void CreateIngredient(Ingredient ingredient);

        public Task<List<Ingredient>> getAllByRecipeIdAsync(int recipeId);
    }
}
