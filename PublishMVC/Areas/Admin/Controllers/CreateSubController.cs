using Data.DataContext;
using Data.Models;
using Data.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PublishMVC.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class CreateSubController : Controller
    {


        private readonly PublishDbContext _context;
        public CreateSubController(PublishDbContext context)
        {
            _context = context;     
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
		public  async Task<IActionResult> CreateSub(VMSubscription subDTO)

		{

            Subscription sub = new Subscription { 
            Price=subDTO.Price,
             Desctiprion=subDTO.Description,
            Title=subDTO.Title,
            };

             _context.Subscriptions.Add(sub);
            await _context.SaveChangesAsync();
			return RedirectToAction("index", "home", new { area = "reader" });

		}
	}
}
