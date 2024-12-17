using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Controllers.WriterPanel
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
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


        [HttpGet]
        public IActionResult NewHeading()
        {
            List<SelectListItem> valueCategories = (from x in categoryManager.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryId.ToString()

                                                    }).ToList();
            ViewBag.vlc = valueCategories;
            return View();
        }

        [HttpPost]
        public IActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = 1;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }


        [HttpGet]
        public IActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategories = (from x in categoryManager.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryId.ToString()

                                                    }).ToList();

            ViewBag.vlc = valueCategories;
            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public IActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
    }
}
