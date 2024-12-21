using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UI.Controllers.WriterPanel
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public IActionResult MyContent(string email)
        {
            Context context = new Context();
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            email = User.FindFirstValue(ClaimTypes.Email);

            // Eğer claim değeri yoksa, boş dönecektir
            if (string.IsNullOrEmpty(email))
            {
                // Eğer claim bilgisi yoksa, kullanıcıyı giriş sayfasına yönlendirebilirsiniz
                return RedirectToAction("Login", "Account");
            }

            var writerIdInfo = context.Writers.Where(x=>x.WriterEmail == email).Select(x=>x.WriterId).FirstOrDefault();
            ViewBag.d = email;
            var contentValues = contentManager.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }
    }
}
