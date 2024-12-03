using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using webgk.Models;
using System.Threading.Tasks;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (AuthenticateUser(model.Username, model.Password))
            {
                await SignInUser(model.Username);
                TempData["SuccessMessage"] = "Đăng nhập thành công!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không đúng.";
            }
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }

    private bool AuthenticateUser(string username, string password)
    {
        // Thay thế bằng logic kiểm tra tài khoản người dùng từ cơ sở dữ liệu
        return (username == "admin" && password == "123456"); // Ví dụ đơn giản
    }

    private async Task SignInUser(string username)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
    }
}
