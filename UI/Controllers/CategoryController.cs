using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class CategoryController : Controller
    {    
        CategoryManager categoryManager = new CategoryManager();
        //Get: Category
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCategoryList()
        {
            var categoryValues = categoryManager.GetAllBL();
            return View(categoryValues);
        }
    }
}
