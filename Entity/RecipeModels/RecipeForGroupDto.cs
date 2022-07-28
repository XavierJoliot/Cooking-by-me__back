using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.StepModels;

namespace CookingByMe_back.Models.RecipeModels
{
    public class RecipeForGroupDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public List<GroupForRecipeDto> GroupsList { get; set; } = new List<GroupForRecipeDto>();
        public int? Duration { get; set; }

        public int Quantity { get; set; }

        public string? ImagePath { get; set; }

        public string? Note { get; set; }

        public List<Step> StepsList { get; set; } = new List<Step>();

        public List<Ingredient> IngredientsList { get; set; } = new List<Ingredient>();

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
