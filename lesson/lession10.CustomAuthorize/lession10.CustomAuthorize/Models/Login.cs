using System.ComponentModel.DataAnnotations;

namespace lession10.CustomAuthorize.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        public string Email { get; set;  }
        [Required(ErrorMessage ="Mật khẩu không được để trống")]
        public string Password { get; set; }
    }
}
