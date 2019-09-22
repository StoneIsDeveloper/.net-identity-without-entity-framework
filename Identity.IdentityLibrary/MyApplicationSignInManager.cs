using Identity.ApiLibrary;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IdentityLibrary
{
    public class MyApplicationSignInManager : SignInManager<MyUser, string>
    {

        public MyApplicationSignInManager(MyApplicationUserManager userManager, IAuthenticationManager authenticationManager)
           : base(userManager, authenticationManager)
        {
            UserManager = userManager;
        }


        public override Task<ClaimsIdentity> CreateUserIdentityAsync(MyUser user)
        {
            return user.GenerateUserIdentityAsync((MyApplicationUserManager)UserManager);
        }

        public static MyApplicationSignInManager Create(IdentityFactoryOptions<MyApplicationSignInManager> options, IOwinContext context)
        {
            return new MyApplicationSignInManager(context.GetUserManager<MyApplicationUserManager>(), context.Authentication);
        }

       public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            // here goes the external username and password look up
            var  user = new AuthApi().GetUser(userName);
            var verificationResult =  UserManager.PasswordHasher.VerifyHashedPassword(user.Password,password);
            if(verificationResult == PasswordVerificationResult.Success)
            {
                return base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
            }
            else
            {
                return Task.FromResult(SignInStatus.Failure);
            }
            //if (userName.ToLower() == "username" && password.ToLower() == "password")
            //{
            //    return base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
            //}
            //else
            //{
            //    return Task.FromResult(SignInStatus.Failure);
            //}
        }

    }
}
