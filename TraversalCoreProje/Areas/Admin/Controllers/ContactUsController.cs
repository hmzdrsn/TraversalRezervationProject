using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactUsController : Controller
	{
		private readonly IContactUsService _ContactUs;

		public ContactUsController(IContactUsService contactUs)
		{
			_ContactUs = contactUs;
		}
		public IActionResult Index()
		{
			var values  =_ContactUs.TGetListContactUsByTrue();
			return View(values);
		}
	}
}
