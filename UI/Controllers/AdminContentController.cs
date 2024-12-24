using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AdminContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContentByHeading(int id) //Başlıkları içeriğe göre getir
        {
            var contentValues = contentManager.GetListByHeadingId(id);
            return View(contentValues);
        }

        public IActionResult GetAllContent(string p)
        {
            var values = contentManager.GetList(p);
            
            //var values = context.Contents.ToList();
            return View(values);
        }
    }
}
