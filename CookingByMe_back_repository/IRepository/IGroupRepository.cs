using CookingByMe_back.Models.GroupModels;

namespace CookingByMe_back.Core.IRepository
{
    public interface IGroupRepository : IRepository<Group>
    {
        public Task<List<Group>> GetAllGroupsAsync();

        public Task<Group?> GetGroupByIdAsync(int id);

        public void CreateGroup(Group group);

        public void UpdateGroup(Group group);

        public void DeleteGroup(Group group);
    }
}
