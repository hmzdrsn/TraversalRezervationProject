using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.ReservationDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationService _destinationService;

        public ReservationController(IReservationService reservationService, UserManager<AppUser> userManager, IDestinationService destinationService)
        {
            _reservationService = reservationService;
            _userManager = userManager;
            _destinationService = destinationService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = _reservationService.TGetListWithAll();

            var selectValues = new SelectList(_reservationService.TGetList(), "ReservationID", "Status");
            ViewBag.Status = selectValues;
            return View(model);
        }

        [HttpPost]
        
        public IActionResult Index(string status)
        {
            var values = status.Split(',');
            var userID = Convert.ToInt32(values[0]);
            var statusValue = values[1];
            var resData = _reservationService.TGetById(userID);
            resData.Status = statusValue;
            _reservationService.TUpdate(resData);

            var model = _reservationService.TGetListWithAll();
            var selectValues = new SelectList(_reservationService.TGetList(), "ReservationID", "Status");
            ViewBag.Status = selectValues;
            return View("Index", model);

        }
    }
}