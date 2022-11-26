using Data.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PublishMVC.Areas.Reader.Controllers
{

    [Area("Reader")]
    public class checkoutController : Controller
    {

        private readonly PublishDbContext _context;
        public checkoutController(PublishDbContext context)
        {
            this._context = context;

        }

        public async Task<IActionResult> Index()
        {
            var sub = await _context.Subscriptions.Include(e => e.Publish).ToListAsync();
            return View(sub);
        }

        public async Task<IActionResult> MoreinfoSubscription(int? id)
        {
            Console.WriteLine(id);
            var sub = await _context.Subscriptions.FindAsync(id);
            return View(sub);
        }

        public async Task<IActionResult> CreateOrder(int? id)
        {
            var sub = await _context.Subscriptions.FindAsync(id);
            var user = await _context.Users.Include(e => e.Subscription).Where(e => e.UserId == 1).FirstOrDefaultAsync();//chagne id
            user.Subscription.Add(sub);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
