using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var value = destinationManager.TGetList();
            return View(value);
        }
        [HttpGet]
        public async Task< IActionResult >DestinationDetails(int id)         
        {
            ViewBag.i = id;
            ViewBag.destID = id;
            var data = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = data.Id;
            var values = destinationManager.TGetDestinationWithGuide(id);
            return View(values);
        }
        //[HttpPost]
        //public IActionResult DestinationDetail(Destination p) 
        //{
        //    return View();
        //}
    }
}
