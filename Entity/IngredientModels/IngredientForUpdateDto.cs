using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.IngredientModels
{
    public class IngredientForUpdateDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(255)]
        public string Unit { get; set; }
    }
}
