using DTO.DTOs;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.ViewModels.Product
{
    public class AddOrUpdateProduct
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required, MaxLength(50)]
        public string ImagePath { get; set; }

        [Required]
        public int CategoryId { get; set; }

    }
}
