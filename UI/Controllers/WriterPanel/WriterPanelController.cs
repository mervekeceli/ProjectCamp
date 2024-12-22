using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace UI.Controllers.WriterPanel
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        Context context = new Context();
        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult MyHeading(string email)
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
            var values = headingManager.GetListByWriter(writerIdInfo);
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
            string writerMailInfo = User.FindFirstValue(ClaimTypes.Email);
            var writerIdInfo = context.Writers.Where(x => x.WriterEmail == writerMailInfo).Select(x => x.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerIdInfo;
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

        public IActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }

        public IActionResult AllHeading()
        {
            var allHeadings = headingManager.GetList();
            return View(allHeadings);
        }
    }
}
