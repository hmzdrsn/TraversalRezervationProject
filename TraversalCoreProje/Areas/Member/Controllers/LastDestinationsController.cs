using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class LastDestinationsController : Controller
    {
        private readonly IDestinationService _destinationService;

        public LastDestinationsController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var data = _destinationService.TGetLast4Destinations();
            return View(data);
        }
    }
}
