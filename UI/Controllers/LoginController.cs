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
                // Cookie Authentication ile oturum açma
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.AdminUserName),
                    new Claim(ClaimTypes.Role, adminUserInfo.AdminRole)

                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Cookie Authentication ile oturum açma
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

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
