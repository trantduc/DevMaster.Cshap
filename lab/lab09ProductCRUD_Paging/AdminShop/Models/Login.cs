using System.ComponentModel.DataAnnotations;

namespace AdminShop.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
