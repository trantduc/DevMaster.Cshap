using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson09_Session_Cookie.Models
{
    [Table("AdminUser")]
    public class AdminUser
    {
        [Key]
        public int Id { get; set; }

        public string? AccountName { get; set; }

        public string? Password { get; set; }

        public int? MaNhanSu { get; set; }

        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Avatar { get; set; }

        public int? IdPhongBan { get; set; }

        public DateTime? NgayTao { get; set; }

        public string? NguoiTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        public string? NguoiCapNhat { get; set; }

        public string? SessionToken { get; set; }

        public string? Salt { get; set; }

        public bool? IsAdmin { get; set; }

        public int? TrangThai { get; set; }
    }
}