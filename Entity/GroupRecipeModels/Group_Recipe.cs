using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.RecipeModels;
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.GroupRecipeModels
{
    public class Group_Recipe
    {
        [Required]
        public int Id { get; set; }


        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }


        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
