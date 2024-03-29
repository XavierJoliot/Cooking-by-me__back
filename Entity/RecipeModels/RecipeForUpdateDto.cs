﻿using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.StepModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.RecipeModels
{
    public class RecipeForUpdateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        public int? Duration { get; set; }

        public int Quantity { get; set; }

        public IFormFile? ImagePath { get; set; }

        public string? Note { get; set; }

        public List<StepForUpdateFromRecipeDto>? StepsList { get; set; }

        public List<IngredientForUpdateFromRecipeDto>? IngredientsList { get; set; }

        public List<int>? GroupIds { get; set; }
    }
}
