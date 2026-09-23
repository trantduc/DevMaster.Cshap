using DemoDataValidationLesson05.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace DemoDataValidationLesson05.Controllers
{
    public class MemberController : Controller
    {
        public static List<Member> _member = new List<Member>()
        {
            new Member(){ MemberID = "01", FullName ="Trần Việt ĐỨc" , Email ="tranvietduc@gmail.com", Password ="12345",
                Phone ="0362382600", Birtday = DateTime.Parse("12/08/1999"), UserName="Member1"
            }
        };
        public IActionResult Index()
        {
            return View(_member);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Member member)
        {
            string msg = null;
            bool validate = true;
            if (member.UserName.Length < 3 || member.UserName.Length > 20)
            {
                msg = "<li>Tên đăng nhập phải có độ dài từ 3-20 ký tự </li>";
                validate = false;
            }
            string patternemail = @"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
            if (!Regex.IsMatch(member.Email, patternemail))
            {
                msg += "<li>Email không đúng định dạng</li>";
                validate = false;
            }
            // cộng thêm 18 năm
            if (member.Birtday.AddYears(18) > DateTime.Now)
            {
                msg += "<li>Bạn chưa đủ 18 tuổi</li>";
                validate = false;
            }
            string patternphone = @"^0\d{9,12}$";
            if (!Regex.IsMatch(member.Phone, patternphone))
            {
                msg += "<li>Số điện thoại không hợp lệ</li>";
                validate = false;
            }
            if (validate)
            {
                member.MemberID = Guid.NewGuid().ToString();
                _member.Add(member);
                // return về trang index
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "<div class='alert alert-danger'>" + msg + "</div>";
                return View(member);
            }
        }
    }
}
