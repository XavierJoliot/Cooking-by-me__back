﻿using System.ComponentModel.DataAnnotations;

namespace CookingByMe_back.Models.Ingredient
{
    public class IngredientForUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(255)]
        public string Unit { get; set; }
    }
}
