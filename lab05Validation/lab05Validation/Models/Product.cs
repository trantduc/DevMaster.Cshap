using System.ComponentModel.DataAnnotations;

namespace lab05Validation.Models
{
    public class Product
    {
        // Bỏ [Required] nếu Id do hệ thống tự sinh (Guid) trong Controller
        public string? Id { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Tên phải từ 6 đến 150 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ảnh")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        [Range(100000, double.MaxValue, ErrorMessage = "Giá chuẩn nhỏ nhất là 100.000")]
        public float? Price { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        public float? SalePrice { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        [MaxLength(1500, ErrorMessage = "Không vượt quá 1.500 ký tự")]
        // Đã sửa lại Regex cấm các từ nhạy cảm chuẩn xác
        [RegularExpression(@"^(?!.*?(lừa đảo|hàng giả|sex|18\+|die|admin|fack|fuck)).*$", ErrorMessage = "Không được chứa từ nhạy cảm")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        public int? CategoryId { get; set; }

        public Category? category { get; set; }
    }
}