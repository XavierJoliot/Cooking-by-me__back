using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.IngredientModels;
using Microsoft.EntityFrameworkCore;

namespace CookingByMe_back.Core.Repository
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(CookingByMeContext context) : base(context)
        {
        }

        public async Task<Ingredient?> GetIngredientByIdAsync(int id)
        {
            return await FindByCondition(s => s.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public void CreateIngredient(Ingredient ingredient)
        {
            Create(ingredient);
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            ingredient.UpdatedAt = DateTime.Now;
            Update(ingredient);
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            Delete(ingredient);
        }
    }
}
