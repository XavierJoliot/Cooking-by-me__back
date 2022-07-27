using CookingByMe_back.Models.Recipe;
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.Group
{
    public class GroupDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public string? ImagePath { get; set; }

        public string? Description { get; set; }

        public List<RecipeDto> RecipesList { get; set; } = new List<RecipeDto>();

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
