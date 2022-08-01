using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.GroupRecipeModels;

namespace CookingByMe_back.Core.IRepository
{
    public interface IGroupRepository : IRepository<Group>
    {
        public Task<List<Group>> GetAllGroupsAsync(string userId);

        public Task<Group?> GetGroupByIdAsync(int id);

        public Task<Group?> FindGroupAsync(int id);

        public void CreateGroup(Group group);

        public void UpdateGroup(Group group);

        public void DeleteGroup(Group group);




        public void AddRecipeAsync(Group_Recipe groupRecipe);
        public Task<Group_Recipe?> FindRecipeFromGroup(int groupId, int recipeId);
        public void RemoveRecipeFromGroup(Group_Recipe groupRecipe);
    }
}
