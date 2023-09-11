using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Migrations;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());
        
        public IActionResult MyCurrentReservation()
        {
            int i = 1002;
            var values = reservationManager.TGetListById(i);
            //var values = reservationManager.TGetById();
            return View(values);
        }
        public IActionResult MyOldReservation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values =(from x in destinationManager.TGetList()
                                   select new SelectListItem
                                   {
                                       Text=x.City,
                                       Value=x.DestinationID.ToString(),
                                   }).ToList();
            ViewBag.v = values;
            return View();  
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.AppUserId = 1002;
            reservationManager.TAdd(p);
            return RedirectToAction("MyCurrentReservation",p.AppUserId);  
        }

    }
}
 