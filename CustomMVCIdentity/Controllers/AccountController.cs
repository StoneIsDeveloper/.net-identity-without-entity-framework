using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CustomMVCIdentity.App_Start;
using CustomMVCIdentity.Models.SystemViewModels;
using IdentityManagement.Entities;

namespace CustomMVCIdentity.Controllers
{
    [Authorize]
    public class Accountontroller :  Controller
    {
        private ApplicationUserManager _userManager;

        // GET: Admin
        public ActionResult Index()
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
                //var user = new MyUser
                //{
                //    UserName = model.Email,
                //    Password = model.Password,
                //    Firstname = model.Firstname,
                //    Lastname = model.Lastname,
                //    Active = true,
                //    EmailVerified = false,
                //    Phone = model.Phone,
                //    PhoneVerified = false,
                //    SecurityStamp = Guid.NewGuid().ToString()
                //};

                // var result = await UserManager.CreateAsync(user, model.Password);


            }


            return View();
        }

    }
}