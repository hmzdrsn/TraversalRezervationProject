using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApiSQL.DAL;
using SignalRApiSQL.Models;

namespace SignalRApiSQL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VisitorController : ControllerBase
	{
		//private readonly Context _context;//kendim yaptım
		private readonly VisitorService _visitorService;
		public VisitorController(VisitorService visitorService)
		{
			_visitorService = visitorService;
			//_context = context;
		}
		[HttpGet]
		public IActionResult CreateVisitor()
		{
			Random random = new Random();
			Enumerable.Range(1, 10).ToList().ForEach(x =>//1,10 arasında sırasıyla sayı oluşturuluyor.
			{
				foreach (ECity item in Enum.GetValues(typeof(ECity)))
				{
					var newVisitor = new Visitor
					{
						City = item,
						CityVisitCount = random.Next(100, 2000),
						VisitDate = DateTime.Now.AddDays(x)
					};
					_visitorService.SaveVisitor(newVisitor).Wait();
					System.Threading.Thread.Sleep(1000);
				}
			});
			return Ok("Ziyaretçiler başarılı bir şekilde eklendi");
		}

		//[HttpGet]//kendim yaptım
		//public IActionResult getVisitors()
		//{
		//	var data = _context.Visitors.ToList();
		//	return Ok(data);
		//}
	}
}
