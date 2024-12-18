using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation_;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.WriterPanel
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public IActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();
            return View(messageList);
        }

        public IActionResult Sendbox()
        {
            var messageList = messageManager.GetListSendbox();
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}
