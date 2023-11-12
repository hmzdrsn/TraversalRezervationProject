using BusinessLayer.Abstract.AbstractUnitOfWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var dataSender = _accountService.TGetByID(model.SenderId);
            var dataReceiver = _accountService.TGetByID(model.ReceiverId);

            dataSender.Amount-= model.Amount;
            dataReceiver.Amount+= model.Amount;

            List<Account> modifiedAccounts= new List<Account>() { 
            dataSender,
            dataReceiver
            };
            _accountService.TMultiUpdate(modifiedAccounts);
            return RedirectToAction("Index");
        }

    }
}
