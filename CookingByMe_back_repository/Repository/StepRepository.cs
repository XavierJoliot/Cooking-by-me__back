using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.Step;

namespace CookingByMe_back.Core.Repository
{
    public class StepRepository : Repository<Step>, IStepRepository
    {
        public Task<List<Step>> getAllByRecipeIdAsync(int recipeId)
        {
            return Task.FromResult(new List<Step>());
        }
    }
}
