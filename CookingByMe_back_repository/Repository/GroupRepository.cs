using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.GroupRecipeModels;
using CookingByMe_back.Models.RecipeModels;
using Microsoft.EntityFrameworkCore;

namespace CookingByMe_back.Core.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(CookingByMeContext context) : base(context)
        {
        }

        public async Task<List<Group>> GetAllGroupsAsync(string userId)
        {
            return await FindAll()
                .Where(g => g.UserId == userId)
                .OrderByDescending(g => g.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Group?> GetGroupByIdAsync(int id)
        {
            return await FindByCondition(s => s.Id.Equals(id))
                .Include(g => g.Group_Recipe!)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Group?> FindGroupAsync(int id)
        {
            return await FindEntityAsync(id);
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
