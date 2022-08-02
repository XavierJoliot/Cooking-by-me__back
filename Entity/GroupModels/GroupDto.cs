using CookingByMe_back.Models.RecipeModels;
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.GroupModels
{
    public class GroupDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? ImagePath { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
