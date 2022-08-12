
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.GroupRecipeModels
{
    public class Group_RecipeForCreationFromGroupDto
    {
        [Required]
        public List<int>? RecipeIds { get; set; }
    }
}
