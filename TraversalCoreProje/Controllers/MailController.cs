using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Diagnostics;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","gmailgeilcek");

            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);

            mimeMessage.To.Add(mailboxAddressTo);
            mimeMessage.Subject=mailRequest.Body;
            mimeMessage.Body = new TextPart() 
            { 
                Text=mailRequest.Body
            };
            SmtpClient smtpClientsmtpClient = new SmtpClient();
            smtpClientsmtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClientsmtpClient.Authenticate("gmailgeilcek", "gmailşifresi gelicek");
            smtpClientsmtpClient.Send(mimeMessage);
            smtpClientsmtpClient.Disconnect(true);

            return View();
        }

    }
}
