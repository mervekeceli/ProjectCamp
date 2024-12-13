using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation_;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        [Authorize]
        public IActionResult Index()
        {
            var categoryValues = categoryManager.GetList();
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
