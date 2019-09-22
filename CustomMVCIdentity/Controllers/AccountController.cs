using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CustomMVCIdentity.App_Start;
using CustomMVCIdentity.Models;
using CustomMVCIdentity.Models.SystemViewModels;
using Identity.ApiLibrary;
using Identity.IdentityLibrary;
using IdentityManagement.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CustomMVCIdentity.Controllers
{
    [Authorize]
    public class AccountController :  BaseController
    {
        private readonly AuthApi _userService;
        private MyApplicationSignInManager _signInManager;
        private MyApplicationUserManager _userManager;

        public AccountController(MyApplicationUserManager userManager, MyApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public MyApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<MyApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public MyApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().Get<MyApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new MyUser
                {
                    UserName = model.Email,
                    Password = model.Password,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Active = true,
                    EmailVerified = false,
                    Phone = model.Phone,
                    PhoneVerified = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    try
                    {
                        var userRecord = _userService.GetUser(model.Email);
                        var code = await UserManager.GenerateEmailConfirmationTokenAsync(userRecord.Id);
                        if (Request.Url != null)
                        {
                            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = userRecord.Id, code }, protocol: Request.Url.Scheme);
                            var message = new MyIdentityMessage
                            {
                                Destination = model.Email,
                                Body = "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>",
                                Subject = "Confirm your account"
                            };
                            await UserManager.EmailService.SendAsync(message);
                        }
                        AddViewMessage(StandardMessages.CustomMessageInfo, "Registeration successful. We have sent you a confirmation email, please confirm your email address to complete your registeration.");
                    }
                    catch (Exception)
                    {
                        AddViewMessage(StandardMessages.CustomMessageError, "Registeration successful but there was an error sending confirmation email.");
                    }

                    try
                    {
                        await SignInManager.PasswordSignInAsync(model.Email, model.Password, true, shouldLockout: false);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);

            }

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}