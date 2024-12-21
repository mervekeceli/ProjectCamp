using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation_;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace UI.Controllers
{
    public class AdminWriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        public IActionResult Index()
        {
            var writerValues = writerManager.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddWriter(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);

            if (results.IsValid)
            {
                writerManager.WriterAdd(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditWriter(int id)
        {
            var writerValue = writerManager.GetById(id);
            return View(writerValue);
        }


        [HttpPost]
        public IActionResult EditWriter(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);

            if (results.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
