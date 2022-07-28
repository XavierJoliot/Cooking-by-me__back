using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.GroupModels;
using Microsoft.EntityFrameworkCore;

namespace CookingByMe_back.Core.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(CookingByMeContext context) : base(context)
        {
        }

        public async Task<List<Group>> GetAllGroupsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Group?> GetGroupByIdAsync(int id)
        {
            return await FindByCondition(s => s.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public void CreateGroup(Group group)
        {
            Create(group);
        }

        public void UpdateGroup(Group group)
        {
            group.UpdatedAt = DateTime.Now;
            Update(group);
        }

        public void DeleteGroup(Group group)
        {
            Delete(group);
        }
    }
}
