using System.ComponentModel.DataAnnotations;

namespace lab05Validation.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

