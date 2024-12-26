using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.AdminPanel
{
    public class AdminGalleryController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());

        [Authorize(Roles = "A")]
        public IActionResult Index()
        {
            var files = imageFileManager.GetList();
            return View(files);
        }
    }
}
