
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.GroupRecipeModels
{
    public class Group_RecipeForCreationFromRecipeDto
    {
        [Required]
        public List<int>? GroupIds { get; set; }
    }
}
