using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.GroupModels
{
    public class GroupForCreationDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string? ImagePath { get; set; }

        public string? Description { get; set; }
    }
}
