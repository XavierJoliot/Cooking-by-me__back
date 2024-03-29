﻿using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.RecipeModels;
using Microsoft.EntityFrameworkCore;

namespace CookingByMe_back.Core.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(CookingByMeContext context) : base(context)
        {
        }

        public async Task<List<Recipe>> GetAllCookingRecipesAsync()
        {
            return await FindAll().Where(r => r.IsPublic == true).AsNoTracking().ToListAsync();
        }

        public async Task<List<Recipe>> GetAllRecipesAsync(string userId)
        {
            return await FindAll().Where(r => r.UserId == userId).AsNoTracking().ToListAsync();
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            var currentRecipe = await FindByCondition(r => r.Id.Equals(id))
                .Include(r => r.StepsList!.OrderBy(s => s.Order))
                .Include(r => r.IngredientsList)
                .Include(r => r.Group_Recipe!)
                .ThenInclude(gr => gr.Group)
                .OrderByDescending(r => r.CreatedAt)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return currentRecipe;
        }

        public void CreateRecipe(Recipe recipe)
        {
            Create(recipe);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            recipe.UpdatedAt = DateTime.Now;
            Update(recipe);
        }

        public void DeleteRecipe(Recipe recipe)
        {
            Delete(recipe);
        }
    }
}
