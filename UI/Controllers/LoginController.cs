using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AdminLogin(Admin admin)
        {
            Context context = new Context();
            var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName &&
            x.AdminPassword == admin.AdminPassword);

            if (adminUserInfo != null)
            {
                //Yönlendirme işlemleri
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
