using CookingByMe_back.Models.RecipeModels;
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.GroupRecipeModels
{
    public class Group_RecipeForGroupDto
    {
        [Required]
        public int Id { get; set; }


        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
