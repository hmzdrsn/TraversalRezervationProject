using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Attributes;
using TraversalCoreProje.CQRS.Commands.GuideCommands;
using TraversalCoreProje.CQRS.Queries.GuideQueries;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _mediator.Send(new GetAllGuideQuery());
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetGuide(int id)
        {
            var data = await _mediator.Send(new GetByIdGuideQuery(id));
            return View(data);
        }

        [HttpGet]
        public IActionResult CreateGuide()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGuide(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteGuide(int id)
        {
            await _mediator.Send(new DeleteGuideCommand(id));
            return NoContent();
        }

    }
}
