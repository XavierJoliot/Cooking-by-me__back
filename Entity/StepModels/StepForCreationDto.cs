using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.StepModels
{
    public class StepForCreationDto
    {
        [Required]
        public int RecipeId { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
