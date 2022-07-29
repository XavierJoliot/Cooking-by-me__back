using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingByMe_back.Models.GroupModels
{
    public class GroupForCreationDto
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        public string? ImageName { get; set; }

        [NotMapped]
        public IFormFile? ImagePath { get; set; }

        public string? Description { get; set; }
    }
}
