using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
namespace UI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 404)
            {
                return View("NotFound");
            }
            return View("Error");
        }
    }
}
