﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IdentityLibrary
{
    public class MyApplicationUserManager : UserManager<MyUser,string>
    {
        public MyApplicationUserManager(IUserStore<MyUser,string> store)
            :base(store)
        { }

        public static MyApplicationUserManager Create(IdentityFactoryOptions<MyApplicationUserManager> options,IOwinContext context)
        {
            var manager = new MyApplicationUserManager(new MyUserStore(CurrentUser.GetCurrentUserInfo()))
            {
                PasswordHasher = new MyPasswordHasher()
            };

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<MyUser, string>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = false;
            //manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //manager.MaxFailedAccessAttemptsBeforeLockout = 5;
           
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<MyUser, string>
            {
                MessageFormat = "Your security code is {0}"
            });

            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<MyUser, string>
            {
                Subject = "Welcome to Identity ststem",
                BodyFormat = "Your security code is {0}"
            });

            manager.EmailService = new MyEmailService();
            manager.SmsService = new MySmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if(manager.UserTokenProvider == null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<MyUser, string>(dataProtectionProvider.Create("Stone ASP.NET Identity"));
            }
            return manager;
        }

     

    }
}
