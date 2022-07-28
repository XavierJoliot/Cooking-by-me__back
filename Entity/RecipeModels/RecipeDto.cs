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
        public string UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public int? Duration { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string? ImagePath { get; set; }

        public string? Note { get; set; }

        public List<Ingredient> IngredientList { get; set; } = new List<Ingredient>();

        public List<Step> StepList { get; set; } = new List<Step>();

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
