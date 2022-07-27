using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.RecipeModels
{
    public class RecipeForUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public int? GroupId { get; set; }

        [Required]
        public string Title { get; set; }

        public int? Duration { get; set; }

        public int Quantity { get; set; }

        public string? ImagePath { get; set; }

        public string? Note { get; set; }
    }
}
