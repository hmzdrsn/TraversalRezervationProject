using DocumentFormat.OpenXml.Vml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByIdHandler _getDestinationByIdHandler;
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly DeleteDestinationCommandHandler _deleteDestinationHandler;
        public DestinationCQRSController(
            GetAllDestinationQueryHandler getAllDestinationQueryHandler,
            GetDestinationByIdHandler getDestinationByIdHandler,
            CreateDestinationCommandHandler createDestinationCommandHandler,
            DeleteDestinationCommandHandler deleteDestinationHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIdHandler = getDestinationByIdHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _deleteDestinationHandler = deleteDestinationHandler;
        }

        public IActionResult Index()
        {
            var data = _getAllDestinationQueryHandler.Handle();
            return View(data);
        }

        [HttpGet]
        public IActionResult GetDestination(int id)
        {
            var data = _getDestinationByIdHandler.Handle(new GetDestinationByIdQuery(id));//GetDestinationByIdQuery sınıfında ctor üzeirnden id ataması yapılıyor.
            return View(data);
        }

        [HttpGet]
        public IActionResult CreateDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDestination(CreateDestinationCommand command)
        {
            if(ModelState.IsValid)
            {
                _createDestinationCommandHandler.Handle(command);
                return RedirectToAction("Index");
            }
            return View(); 
        }

        public IActionResult DeleteDestination(int id)
        {
            _deleteDestinationHandler.Handle(new DeleteDestinationCommand(id));
            return RedirectToAction("Index");
        }

    }
}
