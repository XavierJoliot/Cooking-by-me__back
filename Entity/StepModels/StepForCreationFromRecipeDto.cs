using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.StepModels
{
    public class StepForCreationFromRecipeDto
    {
        [Required]
        public int Order { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
