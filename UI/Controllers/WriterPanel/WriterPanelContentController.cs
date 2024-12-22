using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UI.Controllers.WriterPanel
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        public IActionResult MyContent(string email)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            email = User.FindFirstValue(ClaimTypes.Email);

            // Eğer claim değeri yoksa, boş dönecektir
            if (string.IsNullOrEmpty(email))
            {
                // Eğer claim bilgisi yoksa, kullanıcıyı giriş sayfasına yönlendirebilirsiniz
                return RedirectToAction("Login", "Account");
            }

            var writerIdInfo = context.Writers.Where(x => x.WriterEmail == email).Select(x => x.WriterId).FirstOrDefault();
            ViewBag.d = email;
            var contentValues = contentManager.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }

        [HttpGet]
        public IActionResult AddContent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContent(Content content)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            int writerIdInfo = context.Writers.Where(x => x.WriterEmail == email).Select(x => x.WriterId).FirstOrDefault();

            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerIdInfo;
            content.ContentStatus = true;

            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");
        }
    }
}
