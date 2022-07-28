using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.IngredientModels
{
    public class IngredientDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
