using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.StepModels;

namespace CookingByMe_back.Models.RecipeModels
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }

        public List<Group> GroupList { get; set; } = new List<Group>();

        public string Title { get; set; }

        public int? Duration { get; set; }

        public int Quantity { get; set; }

        public string? ImagePath { get; set; }

        public string? Note { get; set; }

        public List<Step> StepList { get; set; } = new List<Step>();

        public List<Ingredient> IngredientList { get; set; } = new List<Ingredient>();

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}