using CookingByMe_back.Models.StepModels;

namespace CookingByMe_back.Core.IRepository
{
    public interface IStepRepository : IRepository<Step>
    {
        public Task<Step?> GetStepByIdAsync(int id);

        public void CreateStep(Step step);

        public void UpdateStep(Step step);

        public void DeleteStep(Step step);
    }
}
