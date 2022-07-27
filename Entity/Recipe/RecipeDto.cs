using CookingByMe_back.Models.Ingredient;
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.Recipe
{
    public class RecipeDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public int? GroupId { get; set; }

        [Required]
        public string Title { get; set; }

        public int? Duration { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string? ImagePath { get; set; }

        public string? Note { get; set; }

        public List<IngredientDto> IngredientList { get; set; } = new List<IngredientDto>();

        public List<RecipeDto> RecipeList { get; set; } = new List<RecipeDto>();

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
