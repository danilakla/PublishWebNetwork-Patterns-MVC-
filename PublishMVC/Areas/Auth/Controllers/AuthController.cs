using Data.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Data.Models;
using Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace PublishMVC.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class AuthController : Controller
    {


        private readonly PublishDbContext _context;
        public AuthController(PublishDbContext context)
        {
            _context= context;
        }

        public IActionResult Registration()
        {
            

            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "home", new { area = "reader" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(VMAuth UserDTO)
        {
			var userCondidate = await _context.Users.Where(e => e.Email == UserDTO.Email).FirstOrDefaultAsync();
            if (userCondidate != null)
            {
                return View();

            }

			List<Claim>claims= new List<Claim>();
            {
                new Claim(ClaimTypes.NameIdentifier, UserDTO.Email);
            }

            ClaimsIdentity clasims = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh= true,
                IsPersistent=true,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(clasims),properties);

            User user = new User()
            {
                Email = UserDTO.Email,
                IsAdmin = false,
                Password = UserDTO.Password,

            };

            
            var sup = await _context.Subscriptions.Include(e => e.User).Where(e => e.SubscriptionId == 1).FirstOrDefaultAsync();
            sup.User.Add(user);
            await _context.SaveChangesAsync();

           
            return RedirectToAction("SuccesAccessAccoutn");
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "home", new { area = "reader" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(VMAuth UserDTO)
        {
			var userCondidate = await _context.Users.Where(e => e.Email == UserDTO.Email).FirstOrDefaultAsync();
			if (userCondidate == null)
			{
				return View();
			}
			List<Claim> claims = new List<Claim>();
			{
				new Claim(ClaimTypes.NameIdentifier, UserDTO.Email);
			}

			ClaimsIdentity clasims = new ClaimsIdentity(claims,
				CookieAuthenticationDefaults.AuthenticationScheme);

			AuthenticationProperties properties = new AuthenticationProperties()
			{
				AllowRefresh = true,
				IsPersistent = true,
			};

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(clasims), properties);

			User user = new User()
			{
				Email = UserDTO.Email,
				IsAdmin = false,
				Password = UserDTO.Password,

			};
		
            return RedirectToAction("SuccesAccessAccoutn");
        }


        public IActionResult SuccesAccessAccoutn()
        {
        
            return View();
        }

    }
}
