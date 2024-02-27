using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskHub.Core.Domain.Entities.Identity;
using TaskHub.Core.DTO;

namespace TaskHub.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize("NotSignedIn")]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [Authorize("NotSignedIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserSignIn signInModel, string returnUrl)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);

                return View(signInModel);
            }

            var result = await _signInManager.PasswordSignInAsync(signInModel.Username, signInModel.Password, true, false);

            if(result.Succeeded)
            {
                if(string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                {
                    return RedirectToAction("List", "Assignments");
                } else
                {
                    return LocalRedirect(returnUrl);
                }
            } else
            {
                ViewBag.SignInError = "Invalid username or password";
                return View(signInModel);
            }
        }

        [Authorize("NotSignedIn")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize("NotSignedIn")]
        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegister registerModel, string returnUrl)
        {
            if(!ModelState.IsValid)
            {
                return View(registerModel);
            }

            AppUser registeredUser = registerModel.ToAppUserWithoutPassword();

            var result = await _userManager.CreateAsync(registeredUser, registerModel.Password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(registeredUser, true);

                if(string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                {
                    return RedirectToAction("List", "Assignments");
                } else
                {
                    return LocalRedirect(returnUrl);
                }
            } else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }
                return View(registerModel);
            }
        }

        [Authorize("SignedIn")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", new { returnUrl = "" });
        }
    }
}
