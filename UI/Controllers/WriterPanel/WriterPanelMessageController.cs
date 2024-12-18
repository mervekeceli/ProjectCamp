using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation_;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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

        public IActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        public IActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMessage(Message message)
        {
            ValidationResult results = messageValidator.Validate(message);

            if (results.IsValid)
            {
                message.SenderMail = "mervekeceli@gmail.com";
                message.MessageDate = DateTime.Parse(DateTime.Now.ToString());
                messageManager.MessageAdd(message);
                return RedirectToAction("Sendbox");
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
