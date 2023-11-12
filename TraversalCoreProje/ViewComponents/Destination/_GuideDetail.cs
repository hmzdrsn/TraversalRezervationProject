using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Destination
{

    public class _GuideDetail : ViewComponent
    {
        private readonly IGuideService _guideService;

        public _GuideDetail(IGuideService guideService)
        {
            _guideService = guideService;
        }
        public IViewComponentResult Invoke()
        {
            var data = _guideService.TGetById(1);
            return View(data);
        }
    }
}
