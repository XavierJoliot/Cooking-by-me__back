using CookingByMe_back.Models.GroupModels;
using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.GroupRecipeModels
{
    public class Group_RecipeForRecipeDto
    {
        [Required]
        public int Id { get; set; }


        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
