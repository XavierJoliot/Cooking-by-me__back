using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.StepModels;
using Microsoft.EntityFrameworkCore;

namespace CookingByMe_back.Core.Repository
{
    public class StepRepository : Repository<Step>, IStepRepository
    {
        public StepRepository(CookingByMeContext context) : base(context)
        {
        }

        public async Task<Step?> GetStepByIdAsync(int id)
        {
            return await FindByCondition(s => s.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public void CreateStep(Step step)
        {
            Create(step);
        }

        public void UpdateStep(Step step)
        {
            step.UpdatedAt = DateTime.Now;
            Update(step);
        }

        public void DeleteStep(Step step)
        {
            Delete(step);
        }
    }
}
