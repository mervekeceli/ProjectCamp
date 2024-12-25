using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class ChartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CategoryChart()
        {
            List<CategoryClass> data = new List<CategoryClass>{
                new CategoryClass {CategoryName = "Spor", CategoryCount = 10},
                new CategoryClass { CategoryName = "Yazılım", CategoryCount = 15 },
                new CategoryClass { CategoryName = "Teknoloji", CategoryCount = 7 }
            };

            return Json(data);
        }
    }
}
