using CookingByMe_back.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingByMe_back.Models.GroupModels
{
    public class GroupForRecipeDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string? ImagePath { get; set; }

        public string? Description { get; set; }

        public List<RecipeForGroupDto> RecipesList { get; set; } = new List<RecipeForGroupDto>();

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
