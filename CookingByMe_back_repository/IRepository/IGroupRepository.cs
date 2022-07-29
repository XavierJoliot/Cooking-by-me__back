using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.RecipeModels;

namespace CookingByMe_back.Core.IRepository
{
    public interface IGroupRepository : IRepository<Group>
    {
        public Task<List<Group>> GetAllGroupsAsync();

        public Task<Group?> GetGroupByIdAsync(int id);

        public Task<Group?> FindGroupAsync(int id);

        public void AddRecipe(Group group, Recipe recipe);

        public void CreateGroup(Group group);

        public void UpdateGroup(Group group);

        public void DeleteGroup(Group group);
    }
}
