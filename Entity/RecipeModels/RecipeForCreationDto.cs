using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.StepModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingByMe_back.Models.RecipeModels
{
    public class RecipeForCreationDto
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        public int? GroupId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        public int? Duration { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string? ImageName { get; set; }

        [NotMapped]
        public IFormFile? ImagePath { get; set; }

        public string? Note { get; set; }

        public List<StepForCreationDto>? StepsList { get; set; }

        public List<IngredientForCreationDto>? IngredientsList { get; set; }
    }
}
