using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class GuideController : Controller
    {
        GuideManager guideManager = new GuideManager(new EfGuideDal());

        public IActionResult Index()
        {
            var data = guideManager.TGetList();
            return View(data);
        }
    }
}
