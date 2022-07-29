
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.GroupRecipeModels
{
    public class Group_RecipeForCreationDto
    {
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
}
