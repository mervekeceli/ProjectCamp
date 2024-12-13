using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AdminGalleryController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        public IActionResult Index()
        {
            var files = imageFileManager.GetList();
            return View(files);
        }
    }
}
