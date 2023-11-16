using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Org.BouncyCastle.Bcpg;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Mail);
            string passResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passResetToken
            },HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "testtraversaltesttraversal@gmail.com");

            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.Mail);

            mimeMessage.To.Add(mailboxAddressTo);
            mimeMessage.Subject = "Şifre Yenileme Talebi";
            mimeMessage.Body = new TextPart()
            {
                Text = passResetTokenLink
            };
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("testtraversaltesttraversal@gmail.com", "kecw lzqd ddoo wnsm");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);


            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid,string token)
        {
            TempData["token"] = token;
            TempData["userid"] = userid;

            return View();
        }
        [HttpPost]
        public async Task <IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];
            if(userid == null || token ==null)
            {
                //err mess.
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user,token.ToString(),model.Password);
            if(result.Succeeded)
            {
                RedirectToAction("SignIn", "Login");
            }
            return View();
        }

    }
}
