using System.ComponentModel.DataAnnotations;

namespace DbModels.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
