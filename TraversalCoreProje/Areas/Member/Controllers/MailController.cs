using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Member.Controllers
{
	[Area("Member")]
    [Authorize(Roles = "Member")]
    public class MailController : Controller
    {
		private readonly UserManager<AppUser> _userManager;

        public MailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
		[HttpGet]
        public IActionResult Index()
        {
            return View();
        }
		[HttpPost]
        public async Task <IActionResult> Index(MailRequest mailRequest)
        {
			var userName = await _userManager.FindByNameAsync(User.Identity.Name);

			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "testtraversaltesttraversal@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", "hmzdrsn64@gmail.com");
			mimeMessage.To.Add(mailboxAddressTo);
			
			mimeMessage.Subject = mailRequest.Subject+$"Gönderen: {userName.UserName}";
			mimeMessage.Body = new TextPart()
			{
				Text = mailRequest.Body
			};
			SmtpClient smtpClientsmtpClient = new SmtpClient();
			smtpClientsmtpClient.Connect("smtp.gmail.com", 587, false);
			smtpClientsmtpClient.Authenticate("testtraversaltesttraversal@gmail.com", "kecw lzqd ddoo wnsm");
			smtpClientsmtpClient.Send(mimeMessage);
			smtpClientsmtpClient.Disconnect(true);
            ViewBag.status = "Gönderildi";
            return Redirect("/Member/Mail/Index");
        }

    }
}
