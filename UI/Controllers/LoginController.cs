using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> AdminLogin(Admin admin)
        {
            var adminUserInfo = adminManager.Authenticate(admin.AdminUserName, admin.AdminPassword);

            if (adminUserInfo != null)
            {
                // Cookie Authentication ile oturum açma
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.AdminUserName),
                    new Claim(ClaimTypes.Role, adminUserInfo.AdminRole),
                    new Claim(ClaimTypes.NameIdentifier, admin.AdminId.ToString())

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

        [HttpGet]
        public IActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WriterLogin(Writer writer)
        {
            var writerUserInfo = writerManager.Authenticate(writer.WriterEmail, writer.WriterPassword);

            if (writerUserInfo != null)
            {
                // Cookie Authentication ile oturum açma
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, writer.WriterEmail),
                    new Claim(ClaimTypes.NameIdentifier, writer.WriterId.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Cookie Authentication ile oturum açma
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("MyContent", "WriterPanelContent");  // Giriş başarılıysa admin sayfasına yönlendir
            }
            else
            {
                // Giriş başarısızsa login sayfasına yönlendir
                return RedirectToAction("WriterLogin");
            }
        }
    }
}
