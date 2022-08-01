using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.GroupRecipeModels;
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

        public async Task<List<Group>> GetAllGroupsAsync(string userId)
        {
            return await FindAll()
                .Include(g => g.Group_Recipe)
                .Where(g => g.UserId == userId)
                .OrderByDescending(g => g.CreatedAt)
                .ToListAsync();
        }

        public async Task<Group?> GetGroupByIdAsync(int id)
        {
            return await FindByCondition(s => s.Id.Equals(id))
                .Include(g => g.Group_Recipe)
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




        public async void AddRecipeAsync(Group_Recipe groupRecipe)
        {
            await _context.Group_Recipe.AddAsync(groupRecipe);
        }

        public async Task<Group_Recipe?> FindRecipeFromGroup(int groupId, int recipeId)
        {
            return await _context.Group_Recipe
                .Where(g => g.RecipeId == recipeId)
                .Where(g => g.GroupId == groupId)
                .FirstAsync();
        }

        public void RemoveRecipeFromGroup(Group_Recipe recipe)
        {
            _context.Remove(recipe);
        }
    }
}
