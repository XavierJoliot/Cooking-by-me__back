using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingByMe_back_models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public int? GroupId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public int? Duration { get; set; }

        public int Quantity { get; set; }

        public string? ImagePath { get; set; }

        public string? Note { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}