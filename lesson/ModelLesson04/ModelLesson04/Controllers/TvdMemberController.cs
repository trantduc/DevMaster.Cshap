using Microsoft.AspNetCore.Mvc;
using ModelLesson04.Models.DataModels;

namespace ModelLesson04.Controllers
{
    public class TvdMemberController : Controller
    {
        private static readonly List<TvdMember> _tvdMember = new List<TvdMember>()
        {
            new TvdMember
            {
                TvdMemberId = Guid.NewGuid().ToString(),
                TvdUserName = "admin",
                TvdPassword = "Admin@123",
                TvdFullName = "Trịnh Văn Chung",
                TvdEmail = "chungtrinhj@gmail.com"
            },
           new TvdMember
            {
                TvdMemberId = Guid.NewGuid().ToString(),
                TvdUserName = "chungtv",
                TvdPassword = "Chung@123",
                TvdFullName = "Trịnh Văn Chung",
                TvdEmail = "chungtv@gmail.com"
            },
            new TvdMember
            {
                TvdMemberId = Guid.NewGuid().ToString(),
                TvdUserName = "nguyenvanbinh",
                TvdPassword = "Binh@123",
                TvdFullName = "Nguyễn Văn Bình",
                TvdEmail = "nguyenvanbinh@gmail.com"
            },
            new TvdMember
            {
                TvdMemberId = Guid.NewGuid().ToString(),
                TvdUserName = "tranthihoa",
                TvdPassword = "Hoa@123",
                TvdFullName = "Trần Thị Hoa",
                TvdEmail = "tranthihhoa@gmail.com"
            },
            new TvdMember
            {
                TvdMemberId = Guid.NewGuid().ToString(),
                TvdUserName = "leminhduc",
                TvdPassword = "Duc@123",
                TvdFullName = "Lê Minh Đức",
                TvdEmail = "leminhduc@gmail.com"
            }
        };
        public IActionResult Index()
        {
            return View(_tvdMember);
        }
        public IActionResult GetMember()
        {
            var tvdMember = new TvdMember();
            tvdMember.TvdMemberId = Guid.NewGuid().ToString();
            tvdMember.TvdFullName = "Trần Việt Đức";
            tvdMember.TvdUserName = "ductv";
            tvdMember.TvdPassword = "12345a@";
            tvdMember.TvdEmail = "tranvietduc@gmail.com";

            ViewBag.TvdMember = tvdMember;

            return View(tvdMember);
        }
        // GET:
        public ActionResult Create()
        {
            var member = new TvdMember();
            return View(member);
        }
        [HttpPost]
        public IActionResult Create(TvdMember member)
        {
            member.TvdMemberId = Guid.NewGuid().ToString();
            _tvdMember.Add(member);

            return RedirectToAction("Index");

        }
    }
}
