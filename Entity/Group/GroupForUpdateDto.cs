using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.Group
{
    public class GroupForUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string? ImagePath { get; set; }

        public string? Description { get; set; }
    }
}
