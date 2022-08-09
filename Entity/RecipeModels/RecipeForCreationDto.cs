using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.StepModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.RecipeModels
{
    public class RecipeForCreationDto
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        public int? Duration { get; set; }

        [Required]
        public int Quantity { get; set; }

        public IFormFile? ImagePath { get; set; }

        public string? Note { get; set; }

        public bool IsPublic { get; set; }

        public List<StepForCreationFromRecipeDto>? StepsList { get; set; }

        public List<IngredientForCreationFromRecipeDto>? IngredientsList { get; set; }
    }
}
