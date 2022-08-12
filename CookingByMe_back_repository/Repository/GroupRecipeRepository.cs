using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.GroupRecipeModels;
using Microsoft.EntityFrameworkCore;

namespace CookingByMe_back.Core.Repository
{
    public class GroupRecipeRepository : Repository<Group_Recipe>, IGroupRecipeRepository
    {
        public GroupRecipeRepository(CookingByMeContext context) : base(context)
        {
        }

        public async Task<Group_Recipe?> GetGroupRecipeByIdAsync(int id)
        {
            return await FindByCondition(gr => gr.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public void CreateGroupRecipe(Group_Recipe groupRecipe)
        {
            Create(groupRecipe);
        }


        public void DeleteGroupRecipe(Group_Recipe groupRecipe)
        {
            Delete(groupRecipe);
        }
    }
}
