using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab06StudentManager.Models
{
    public class StdClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Không được để trống")]
        [Column(TypeName = "nvarchar(100)")]
        public string ClassName { get; set; } = string.Empty;
    }
}
