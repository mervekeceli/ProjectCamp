using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        public IActionResult Index()
        {
            var writerValues = writerManager.GetList();
            return View(writerValues);
        }
    }
}
