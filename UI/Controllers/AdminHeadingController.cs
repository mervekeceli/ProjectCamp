using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Controllers
{
    public class AdminHeadingController : Controller
    {
        //GET: Heading

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        public IActionResult Index()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }

        [HttpGet]
        public IActionResult AddHeading()
        {
            List<SelectListItem> valueCategories = (from x in categoryManager.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryId.ToString()

                                                    }).ToList();

            List<SelectListItem> valueWriters = (from x in writerManager.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.WriterName + " " + x.WriterSurName,
                                                     Value = x.WriterId.ToString()

                                                 }).ToList();

            ViewBag.vlc = valueCategories;
            ViewBag.vlw = valueWriters;
            return View();
        }

        [HttpPost]
        public IActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        
        public IActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }
    }
}
