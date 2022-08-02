using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.StepModels
{
    public class StepForUpdateFromRecipeDto
    {
        public int? Id { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
