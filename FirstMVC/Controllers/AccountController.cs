using Azure.Identity;
using FirstMVC.Models;
using FirstMVC.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FirstMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SignInManager<ApplicationUser> _SigninManager;

        public AccountController(UserManager<ApplicationUser> UserManager, SignInManager<ApplicationUser> SigninManager)
        {
            _UserManager = UserManager;
            _SigninManager = SigninManager;
        }

        public async Task<IActionResult> SignOut() 
        {
            await _SigninManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLogin(LoginViewModel model) 
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser =
                await _UserManager.FindByNameAsync(model.UserName);
                if (applicationUser != null) 
                {
                    bool found =
                   await _UserManager.CheckPasswordAsync(applicationUser, model.Password);
                    if (found)
                    {
                        var CartID = applicationUser.Cart?.ID;
                        var Claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,applicationUser.UserName),
                            new Claim("CartID",CartID.ToString() ?? "")
                        };

                        var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await _SigninManager.SignInAsync(applicationUser, model.RememberMe, identity.ToString());
                        return RedirectToAction("Index", "Home");
                    }

                }
                ModelState.AddModelError("", " Wrong Username Or Password");
            
            }
            return View("Login",model);
        
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterViewModel model) 
        { 
            if(ModelState.IsValid) 
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.Address = model.Address;
                applicationUser.FName = model.FName;
                applicationUser.LName = model.LName;
                applicationUser.UserName = model.UserName;
                applicationUser.Email = model.Email;
                applicationUser.PhoneNumber = model.PhoneNumber;
                applicationUser.PasswordHash = model.Password;

                 IdentityResult result =  await _UserManager.CreateAsync(applicationUser,model.Password);
                if (result.Succeeded) 
                { 
                    await _UserManager.AddToRoleAsync(applicationUser,"Customer");

                    await _SigninManager.SignInAsync(applicationUser, isPersistent: false);
                    return RedirectToAction("Index","Home");
                }
                foreach (var item in result.Errors)
                {
                        ModelState.AddModelError("",item.Description);
                }

            }
            else
            {
                return View("Register",model);
            }

            return View("Register",model);
        }

        public IActionResult CreateAdmin()
        {
            return View();
        }
    }
}
