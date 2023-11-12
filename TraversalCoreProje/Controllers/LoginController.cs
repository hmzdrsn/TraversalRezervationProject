using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{

    [AllowAnonymous]
    
    public class LoginController : Controller
    {
        
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            if(ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
					Name = p.Name,
					Surname = p.Surname,
					Email = p.Mail,
					UserName = p.Username
				};
                var result =await _userManager.CreateAsync(appUser,p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
            }
            return View(p);
        }
        
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, false);
                    if(result.Succeeded)
                {
                    return RedirectToAction("Index","Profile",new { area = "Member"});
                }
                else
                {
                    return RedirectToAction("SignIn", "Login"); 
                }
            }
            return View(p.Username);
        }

        public async Task<IActionResult> Exit()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }



    }
}
