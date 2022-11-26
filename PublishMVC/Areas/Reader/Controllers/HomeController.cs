using Data.DataContext;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublishMVC.Models;
using System.Diagnostics;
using Data.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Pattern.AbstractFactory.Interface;
using Pattern.Builder;
using Pattern.Decorator;
using Pattern.Stratage.Interface;
using Pattern.Stratage.Class;

namespace PublishMVC.Controllers
{
    [Area("Reader")]
    public class HomeController : Controller
    {

        private readonly PublishDbContext _context;

		private readonly IPublishCatalogAbstractFactory factory;
        private readonly IUser _user;
		private readonly IUser _userClone;

        private readonly ICakeMessageDecorator _decorator;

        private readonly  ICake cake;

        private readonly IDataSave _dataSave;
        private readonly ISave _savePrincep;
		public HomeController(PublishDbContext context, IPublishCatalogAbstractFactory factory, IUser user, ICakeMessageDecorator decorator, ICake cake, IDataSave dataSave, ISave savePrincipe)

        {

            _savePrincep= savePrincipe;
            this._dataSave=dataSave;
            this.cake = cake;
            this._decorator= decorator;
            _context = context;
            this.factory = factory;
            this._user = user;
            _userClone = user.Clone() as IUser;
        }

        
        public async Task<IActionResult>Index()
        {

            _dataSave.saveData(_savePrincep,"email");

			this._decorator.Decorate("some text");
            cake.PrintLayers();

            var list = this.factory.CreateFactory("").CreateCatalog("Your").GetPublish();

            foreach (var item in list)
            {
                Console.WriteLine(item.Desctiprion);

            }
			Console.WriteLine(_user.Name);
			Console.WriteLine(_user.Address);
            Console.WriteLine("clone");
			Console.WriteLine(_userClone.Name);
			Console.WriteLine(_userClone.Address);

			

            var user = await _context.Users.Include(e => e.Subscription).Where(e => e.UserId == 2).SingleOrDefaultAsync(); ;

            var sub = await _context.Subscriptions.FindAsync(1);
            user.Subscription.Add(sub);
            await _context.SaveChangesAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}