﻿using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.RecipeModels;
using CookingByMe_back.Models.StepModels;

namespace CookingByMe_back.Core.IRepository
{
    public interface IRecipeRepository : IRepository<Recipe> 
    {
        public Task<List<Recipe>> GetAllCookingRecipesAsync();

        public Task<List<Recipe>> GetAllRecipesAsync(string userId);

        public Task<Recipe?> GetRecipeByIdAsync(int id);

        public void CreateRecipe(Recipe recipe);

        public void UpdateRecipe(Recipe recipe);

        public void DeleteRecipe(Recipe recipe);
    }
}
