﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Migrations;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;

namespace TraversalCoreProje.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/[controller]/[action]")]
    [Authorize(Roles = "Member")]
    public class ReservationController : Controller
	{
		DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
		ReservationManager reservationManager = new ReservationManager(new EfReservationDal());

		private readonly UserManager<AppUser> _userManager;

		public ReservationController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> MyCurrentReservation()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valueslist = reservationManager.GetListReservationByAccepted(values.Id);
			return View(valueslist);
		}
		public async Task<IActionResult> MyOldReservation()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valueslist = reservationManager.GetListReservationByPrevious(values.Id);
			return View(valueslist);
		}
		public async Task<IActionResult> MyApprovalReservation()//onay bekleyen
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valueslist = reservationManager.GetListReservationByWaitApproval(values.Id);
			return View(valueslist);
		}

		[HttpGet]
		public IActionResult NewReservation()
		{
			//List<SelectListItem> values = (from x in destinationManager.TGetList()
			//							   select new SelectListItem
			//							   {
			//								   Text = x.City,
			//								   Value = x.DestinationID.ToString(),
			//							   }).ToList();
			//ViewBag.v = values;



			//var data = destinationManager.TGetList();


			//ViewBag.data = new SelectList(data, "DestinationId", "City");
			//Reservation model = new Reservation()
			//{
			//	DestinationID = 1
			//};

			var values = (from x in destinationManager.TGetList()
						  select new SelectListItem
						  {
							  Text = x.City,
							  Value = x.DestinationID.ToString(),
						  }).ToList();
			var selectValues2 = new SelectList(destinationManager.TGetList(), "DestinationID", "City");
			ViewBag.data2 = selectValues2;
			var selectValues = new SelectList(values, "DestinationID", "City");
			ViewBag.data = selectValues;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> NewReservation(Reservation p)
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var user = await _userManager.FindByIdAsync(userId);
			p.AppUserId = user.Id;
			p.Status = "Onay Bekliyor";
			reservationManager.TAdd(p);
			return RedirectToAction("MyCurrentReservation", p.AppUserId);
		}
		public IActionResult Deneme()
		{
			return View();
		}

	}
}
