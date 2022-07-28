using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.StepModels;
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.RecipeModels
{
    public class RecipeForCreationDto
    {
        [Required]
        public string UserId { get; set; }

        public int? GroupId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public int? Duration { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string? ImagePath { get; set; }

        public string? Note { get; set; }

        public List<StepForCreationDto>? StepsList { get; set; }

        public List<IngredientForCreationDto>? IngredientsList { get; set; }
    }
}
