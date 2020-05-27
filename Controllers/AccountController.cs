using System.Threading.Tasks;
using BTL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BTL.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        
        private const string adminUser = "admin";
        private const string adminPassword = "Bonghoatrang1@!";
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [AllowAnonymous]
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginRequest)
        {
            IdentityUser admin = await _userManager.FindByIdAsync(adminUser);
            if (admin == null)
            {
                admin=new IdentityUser("admin");
                await _userManager.CreateAsync(admin, adminPassword);
            }
            
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(loginRequest.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, loginRequest.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction("Index", "ManageProduct");
                    }
                }
            }

            return View(loginRequest);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}