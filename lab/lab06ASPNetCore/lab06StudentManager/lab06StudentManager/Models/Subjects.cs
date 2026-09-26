using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab06StudentManager.Models
{
    [Table("Subjects")]
    public class Subjects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên môn học không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên môn học")]
        public string SubjectName { get; set; } = string.Empty;
    }
}
