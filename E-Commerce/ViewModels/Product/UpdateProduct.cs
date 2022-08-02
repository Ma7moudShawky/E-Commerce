﻿using E_Commerce.Validators;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.ViewModels.Product
{
    public class UpdateProduct
    {

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]

        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
