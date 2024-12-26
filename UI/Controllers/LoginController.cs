using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UI.reCAPTCHA;

namespace UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ReCAPTCHAaService _recaptchaService;

        AdminManager adminManager = new AdminManager(new EfAdminDal());
        WriterLoginManager writerManager = new WriterLoginManager(new EfWriterDal());

        //public LoginController(ReCAPTCHAaService recaptchaService)
        //{
        //    _recaptchaService = recaptchaService;
        //}

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
        public async Task<IActionResult> WriterLogin(Writer writer, string recaptchaResponse)
        {
            var writerUserInfo = writerManager.Authenticate(writer.WriterEmail, writer.WriterPassword);

            if (writerUserInfo != null)
            {
                //// ReCAPTCHA doğrulamasını yap
                //var isCaptchaValid = await _recaptchaService.ValidateRecaptchaAsync(recaptchaResponse);

                //if (!isCaptchaValid)
                //{
                //    ModelState.AddModelError(string.Empty, "ReCAPTCHA doğrulaması başarısız oldu.");
                //    return View();
                //}

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

        public async Task<IActionResult> Logout()
        {
            // Kullanıcı kimliğini almak için claims üzerinden kontrol yapıyoruz
            var userRoles = HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            // Kullanıcı kimliğini temizle
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (userRoles.Contains("A"))
            {
                return RedirectToAction("AdminLogin", "Login");
            }
            // Login sayfasına yönlendirme
            return RedirectToAction("Headings", "Default");
        }
    }
}
