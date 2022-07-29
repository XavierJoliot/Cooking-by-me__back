using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.RecipeModels;
using Microsoft.EntityFrameworkCore;

namespace CookingByMe_back.Core.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private CookingByMeContext _context;
        public GroupRepository(CookingByMeContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Group>> GetAllGroupsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Group?> GetGroupByIdAsync(int id)
        {
            return await FindByCondition(s => s.Id.Equals(id))
                .Include(g => g.RecipesList)
                .FirstOrDefaultAsync();
        }

        public async Task<Group?> FindGroupAsync(int id)
        {
            return await FindEntityAsync(id);
        }

        public void AddRecipe(Group group, Recipe recipe)
        {
            group.RecipesList.Add(recipe);
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
