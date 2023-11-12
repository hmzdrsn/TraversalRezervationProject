using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ListJsonDestination()
        {
            var value =  _destinationService.TGetList();
            var jsonData =  JsonConvert.SerializeObject(value);
            return Json(jsonData);
        } 
        
        public IActionResult ListJsonDestinationById(int DestId)
        {
            var value =  _destinationService.TGetById(DestId);
            var jsonData =  JsonConvert.SerializeObject(value);
            return Json(jsonData);
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
			var value = JsonConvert.SerializeObject(destination);
			return Json(value);

		}

        public IActionResult DeleteDestination(int id)
        {
            _destinationService.TDeleteDestinationById(id);
            return NoContent();
        }

        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationService.TUpdate(destination);
			var value = JsonConvert.SerializeObject(destination);
			return Json(value);
		}
    }
}
