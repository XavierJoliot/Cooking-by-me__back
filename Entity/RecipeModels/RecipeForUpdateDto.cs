using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.StepModels;
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.RecipeModels
{
    public class RecipeForUpdateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        public int? Duration { get; set; }

        public int Quantity { get; set; }

        public string? ImagePath { get; set; }

        public string? Note { get; set; }

        public List<StepForCreationFromRecipeDto>? StepsList { get; set; }

        public List<IngredientForCreationFromRecipeDto>? IngredientsList { get; set; }
    }
}
