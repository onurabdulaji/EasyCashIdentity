using EasyCashIdentity.EntityLayer.Concrete;
using EasyCashIdentity.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LogInViewModel logInViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(
                logInViewModel.Username,
                logInViewModel.Password,
                false,
                true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(logInViewModel.Username);
                if (user.EmailConfirmed == true)
                {
                    return RedirectToAction("Index", "MyProfile");
                }
                // else lutfen mail adresinizi onaylayin
            }
            // kullanici adi veya sifre hatali
            return View();
        }
    }
}
