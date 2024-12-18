using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.WriterPanel
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public IActionResult MyContent()
        {
            var contentValues = contentManager.GetListByWriter();
            return View(contentValues);
        }
    }
}
