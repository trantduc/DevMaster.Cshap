using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab06StudentManager.Models
{
    public class Marks
    {
        [Required(ErrorMessage = "Vui lòng chọn môn học")]
        [Display(Name = "Môn học")]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn sinh viên")]
        [Display(Name = "Sinh viên")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Điểm số không được để trống")]
        [Range(0, 10, ErrorMessage = "Điểm số phải nằm trong khoảng từ 0 đến 10")]
        [Display(Name = "Điểm số")]
        public float Score { get; set; }

        // Navigation properties (Khóa ngoại)
        [ForeignKey("SubjectId")]
        public virtual Subjects Subject { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

    }
}
