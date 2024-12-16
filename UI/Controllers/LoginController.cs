using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminLogin(Admin admin)
        {
            var context = new Context();
            var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);

            if (adminUserInfo != null)
            {
                // Kullanıcı bilgilerini session'a kaydedin
                HttpContext.Session.SetString("AdminUserName", admin.AdminUserName);  // Admin adı
                HttpContext.Session.SetInt32("AdminId", adminUserInfo.AdminId);  // Admin ID

                // Cookie Authentication ile oturum açma
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.AdminUserName)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "AdminCategory");  // Giriş başarılıysa admin sayfasına yönlendir
            }
            else
            {
                // Giriş başarısızsa login sayfasına yönlendir
                return RedirectToAction("Login", "Admin");
            }
        }
    }
}
