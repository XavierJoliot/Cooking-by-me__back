using CookingByMe_back.Models.IngredientModels;

namespace CookingByMe_back.Core.IRepository
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        public Task<Ingredient?> GetIngredientByIdAsync(int id);

        public void CreateIngredient(Ingredient ingredient);

        public void UpdateIngredient(Ingredient ingredient);

        public void DeleteIngredient(Ingredient ingredient);
    }
}
