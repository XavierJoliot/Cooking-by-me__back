using CookingByMe_back.Models.StepModels;

namespace CookingByMe_back.Core.IRepository
{
    public interface IStepRepository : IRepository<Step>
    {
        public void CreateStep(Step step);
        public Task<List<Step>> getAllByRecipeIdAsync(int recipeId);
    }
}
