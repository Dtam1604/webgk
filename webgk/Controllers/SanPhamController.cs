using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace webgk.Controllers
{
    [Authorize]
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ThemMoi()
        {
            return View();
        }
        public IActionResult ChinhSua()
        {
            return View();
        }
        public IActionResult ChiTiet()
        {
            return View();
        }
    }
}
