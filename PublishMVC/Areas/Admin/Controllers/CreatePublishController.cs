using Data.Models.ViewModel;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.DataContext;

namespace PublishMVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CreatePublishController : Controller
	{




		private readonly PublishDbContext _context;
		public CreatePublishController(PublishDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> CreatePublish(VMPublish publishDto)

		{

			Publish sub = new Publish
			{
				Desctiprion = publishDto.Description,
				Title = publishDto.Title,
			};

			var subFromDB = await _context.Subscriptions.Include(e => e.Publish).Where(e => e.SubscriptionId == publishDto.SubId).FirstOrDefaultAsync();
			Console.WriteLine(subFromDB.Desctiprion);
			subFromDB.Publish.Add(sub);

			await _context.SaveChangesAsync();
			return RedirectToAction("index", "home", new { area = "reader" });

		}
	}
}
