using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AdminCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
