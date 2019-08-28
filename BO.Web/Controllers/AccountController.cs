using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weable.TMS.Infrastructure.Extension;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Enumeration;
using Weable.TMS.BO.Web.Controllers;
using Weable.TMS.BO.Web.Models;

namespace Weable.TMS.BO.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<TrainingController> _logger;
        public static readonly string Name = "Account";
        public static readonly string ActionLogin = "Login";
        public static readonly string ActionLogout = "Logout";

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<TrainingController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit() {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditAccountModel model)
        {
            if (ModelState.IsValid)
            {
                Role adminRole = (Role)Enum.Parse(typeof(Role), "Staff");

                // Our default user
                var user = new ApplicationUser
                {
                    FullName = "Tanaphon Kleaklom",
                    Email = "kirataetwo@gmail.com",
                    UserName = model.Username,
                    LockoutEnabled = false
                };

                // Add the user to the database if it doesn't already exist
                if (await _userManager.FindByNameAsync(user.UserName) == null)
                {
                    // WARNING: Do NOT check in credentials of any kind into source control


                    var result = await _userManager.CreateAsync(user, password: model.Password);

                    if (!result.Succeeded)
                    {
                        // FIXME: Do not throw an Exception object
                        throw new Exception("Creating user failed");
                    }

                    // Assign all roles to the default user
                    result = await _userManager.AddToRoleAsync(user, adminRole.GetRoleName());
                    // If you add a role to the enumafter the user is created,
                    // the role will not be assigned to the user as of now

                    if (!result.Succeeded)
                    {
                        // FIXME: Do not throw an Exception object
                        throw new Exception("Adding user to role failed");
                    }
                }

            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "User account locked out.");
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(ActionLogin);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }


    }
}