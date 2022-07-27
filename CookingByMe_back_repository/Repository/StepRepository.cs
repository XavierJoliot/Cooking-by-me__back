using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.StepModels;

namespace CookingByMe_back.Core.Repository
{
    public class StepRepository : Repository<Step>, IStepRepository
    {
        public StepRepository(CookingByMeContext context) : base(context)
        {
        }

        public void CreateStep(Step step)
        {
            Create(step);
        }

        public Task<List<Step>> getAllByRecipeIdAsync(int recipeId)
        {
            return Task.FromResult(new List<Step>());
        }
    }
}
