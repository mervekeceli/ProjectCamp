using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation_;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using X.PagedList.Extensions;

namespace UI.Controllers.AdminPanel
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());


        [Authorize(Roles = "A")]
        public IActionResult Index(int page = 1)
        {
            string adminUserName = User.FindFirstValue(ClaimTypes.Name); //Giriş yapan kullanıcının adını Claims'den alır.

            if (string.IsNullOrEmpty(adminUserName))
            {
                //Eğer session boşsa, login sayfasına yönlendirir.
                return RedirectToAction("Login", "AdminLogin");
            }
            ViewBag.page = page;
            var categoryValues = categoryManager.GetList().ToPagedList(page, 10);
            return View(categoryValues);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult results = validationRules.Validate(category);

            if (results.IsValid)
            {
                categoryManager.CagetgoryAdd(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteCategory(int id)
        {
            var categoryValue = categoryManager.GetById(id);
            categoryManager.CategoryDelete(categoryValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var categoryValues = categoryManager.GetById(id);
            return View(categoryValues);
        }


        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            categoryManager.CategoryUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
