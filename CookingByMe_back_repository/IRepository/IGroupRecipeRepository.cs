using CookingByMe_back.Models.GroupRecipeModels;

namespace CookingByMe_back.Core.IRepository
{
    public interface IGroupRecipeRepository : IRepository<Group_Recipe>
    {
        public Task<Group_Recipe?> GetGroupRecipeByIdAsync(int id);

        public void DeleteGroupRecipe(Group_Recipe groupRecipe);

        public void CreateGroupRecipe(Group_Recipe groupRecipe);
    }
}
