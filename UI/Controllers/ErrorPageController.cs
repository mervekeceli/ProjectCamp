using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
namespace UI.Controllers
{
    public class ErrorPageController : Controller
    {
        [Route("/ErrorPage/Error")]
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 404)
            {
                return View("NotFound");
            }
            if(statusCode == 403)
            {
                return View("Error");
            }
            return View("Error");
        }
    }
}
