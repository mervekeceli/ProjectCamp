using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AdminContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContentByHeading() //Başlıkları içeriğe göre getir
        {
            return View();
        }
    }
}
