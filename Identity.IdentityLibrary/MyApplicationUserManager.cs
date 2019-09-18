using Microsoft.AspNet.Identity;
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
            var manager = new MyApplicationUserManager(new MyUserStore(CurrentUser.GetCurrentUserInfo()));


            return null;
        }

    }
}
