using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoDataValidationLesson05.Models
{
    public class RegisterViewModel
    {
        // tên đăng nhập
        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage ="Tên đăng nhập không được để trống")]
        [StringLength(20,MinimumLength = 3, ErrorMessage = "Tên đăng nhập không được vượt quá 3 - 20 ký tự")]
        public string UserName { get; set; }
        // họ tên
        [DisplayName("Họ và tên đầy đủ")]
        [Required(ErrorMessage = "Người dùng không được để trống")]
        public string FullName { get; set; }
        // mật khẩu
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // mật khẩu
        //[DisplayName("Nhập lại mật khẩu")]
        //[Required(ErrorMessage = "Mật khẩu không được để trống")]
        //[DataType(DataType.Password)]
        //[Compare("Password",ErrorMessage ="Mật khẩu nhập lại không trùng khớp")]
        //public string RePassword { get; set; }

        // email
        [DisplayName("Hòm thư")]
        [Required(ErrorMessage = "Hòm thư không được để trống")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$", ErrorMessage ="Hòm thư không đúng định dạng")]
        public string Email { get; set; }
        // số điện thoại
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^0\\d{9,12}$",ErrorMessage ="Số điện thoại không đúng định dạng")]
        public string Phone { get; set; }
        // ngày tháng năm
        public DateTime Birtday { get; set; }
    }
}
