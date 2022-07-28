using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.RecipeModels
{
    public class RecipeForUpdateDto
    {
        public int? GroupId { get; set; }

        [Required]
        public string Title { get; set; }

        public int? Duration { get; set; }

        public int Quantity { get; set; }

        public string? ImagePath { get; set; }

        public string? Note { get; set; }
    }
}
