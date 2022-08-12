using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.GroupRecipeModels;
using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.StepModels;
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.RecipeModels
{
    public class RecipeDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        public int? Duration { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string? ImagePath { get; set; }

        public string? Note { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<Step>? StepsList { get; set; }
        public ICollection<Ingredient>? IngredientsList { get; set; }
        public ICollection<Group_RecipeForRecipeDto>? Group_Recipe { get; set; }
    }
}
