using CookingByMe_back.Models.Step;

namespace CookingByMe_back.Core.IRepository
{
    public interface IStepRepository : IRepository<Step>
    {
        public Task<List<Step>> getAllByRecipeIdAsync(int recipeId);
    }
}
