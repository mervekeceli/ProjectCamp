using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AdminContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
