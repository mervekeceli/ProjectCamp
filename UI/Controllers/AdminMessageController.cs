using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AdminMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Inbox()
        {
            var messageList = messageManager.GetList();
            return View(messageList);
        }
    }
}
