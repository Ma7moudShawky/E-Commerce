using System.ComponentModel.DataAnnotations;

namespace E_Commerce.ViewModels.Category
{
    public class AddOrUpdateCategory
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }
}
