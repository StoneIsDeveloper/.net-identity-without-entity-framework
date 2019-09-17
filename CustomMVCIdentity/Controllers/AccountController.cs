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

        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserInfo
                {
                    UserName = model.Email,
                    Password = model.Password,
                    Email = model.Email
                };

               // var result = await UserManager.CreateAsync(user, model.Password);


            }


            return View();
        }

    }
}