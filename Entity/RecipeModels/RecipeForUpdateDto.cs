﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingByMe_back.Models.RecipeModels
{
    public class RecipeForUpdateDto
    {

        [Required]
        public string Title { get; set; } = string.Empty;

        public int? Duration { get; set; }

        public int Quantity { get; set; }

        public string? ImageName { get; set; }

        [NotMapped]
        public IFormFile? ImagePath { get; set; }

        public string? Note { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
