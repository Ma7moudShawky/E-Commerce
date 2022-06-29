using DTO.DTOs;

namespace E_Commerce.ViewModels.Product
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string ImagePath { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
