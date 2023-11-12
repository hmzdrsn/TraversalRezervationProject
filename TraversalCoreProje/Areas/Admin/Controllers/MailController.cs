using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "testtraversaltesttraversal@gmail.com");

            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);

            mimeMessage.To.Add(mailboxAddressTo);
            mimeMessage.Subject = mailRequest.Body;
            mimeMessage.Body = new TextPart()
            {
                Text = mailRequest.Body
            };
            SmtpClient smtpClientsmtpClient = new SmtpClient();
            smtpClientsmtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClientsmtpClient.Authenticate("testtraversaltesttraversal@gmail.com", "kecw lzqd ddoo wnsm");
            smtpClientsmtpClient.Send(mimeMessage);
            smtpClientsmtpClient.Disconnect(true);

            return View();
        }

    }
}
