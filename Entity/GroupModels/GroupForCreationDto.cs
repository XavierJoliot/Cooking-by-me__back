using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.GroupModels
{
    public class GroupForCreationDto
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        public string? ImagePath { get; set; }

        public string? Description { get; set; }
    }
}
