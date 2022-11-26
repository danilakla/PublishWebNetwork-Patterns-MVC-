using Data.DataContext;
using Data.Models;
using Data.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PublishMVC.Areas.Reader.Controllers
{
    [Area("Reader")]

	public class PublishController : Controller
    {
        private readonly PublishDbContext _context;
        public PublishController(PublishDbContext context) { 
        _context= context;  
        }
        public async Task<IActionResult> ListPublish(int? id=1)
        {
            var publishes = await _context.Users.Where(e => e.UserId == id).Include(e => e.Subscription).ThenInclude(e => e.Publish).FirstOrDefaultAsync();


            VMPublishList Vmdata = new VMPublishList();
            foreach (var item in publishes.Subscription)
            {

                foreach (var item1 in item.Publish)
                {
					Vmdata.Publishes.Add(item1);

				}
			}
			return View(Vmdata); 
        }

		public async Task<IActionResult> MoreInfo(int? id)
		{
            var publish = await _context.Publishs.FindAsync(id);
			return View(publish);
		}

	}
}
