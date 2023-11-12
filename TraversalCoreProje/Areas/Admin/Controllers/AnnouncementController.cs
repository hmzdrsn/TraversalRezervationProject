using AutoMapper;
using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Drawing.Charts;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        public AnnouncementController(IAnnouncementService announcementService,IMapper mapper)
        {
            _mapper= mapper;
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDto>>(_announcementService.TGetList());
            return View(values);
        }
        [HttpGet]
        public IActionResult AnnouncementAddDto()
        {
            
            return View();
        }
        
        public IActionResult AnnouncementDeleteDto(int id)
        {
            var values = _announcementService.TGetById(id);
            _announcementService.TDelete(values);
            return NoContent();
        }

        [HttpPost]
        public IActionResult AnnouncementAddDto(AnnouncementAddDto announcementAddDto)
        {
            if(ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement
                {
                    Title = announcementAddDto.Title,
                    Content = announcementAddDto.Content,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AnnouncementUpdateDto(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDto>(_announcementService.TGetById(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult AnnouncementUpdateDto(AnnouncementUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement
                {
                    AnnouncementID = model.AnnouncementID,
                    Title = model.Title,
                    Content = model.Content,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }  
       
    }
}
