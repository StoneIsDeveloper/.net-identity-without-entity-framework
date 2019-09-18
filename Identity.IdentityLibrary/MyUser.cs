using Identity.ModelsLibrary;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IdentityLibrary
{
    public class MyUser : User,IUser<string> 
    {
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync()
        //{

        //}
    }
}
