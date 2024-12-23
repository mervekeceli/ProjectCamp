using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation_;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web.Helpers;

namespace UI.Controllers.WriterPanel
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        Context context = new Context();
        public IActionResult Inbox()
        {
            string mail = User.FindFirstValue(ClaimTypes.Email);

            var messageList = messageManager.GetListInbox(mail);
            return View(messageList);
        }

        public IActionResult Sendbox()
        {
            string mail = User.FindFirstValue(ClaimTypes.Email);
            var messageList = messageManager.GetListSendbox(mail);
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
                message.SenderMail = User.FindFirstValue(ClaimTypes.Email);
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
