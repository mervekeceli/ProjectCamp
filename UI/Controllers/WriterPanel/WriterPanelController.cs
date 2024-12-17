using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.WriterPanel
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult MyHeading(int id)
        {
            id = 1;
            var values = headingManager.GetListByWriter(id);
            return View(values);
        }
    }
}
