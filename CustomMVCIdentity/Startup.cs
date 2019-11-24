using CustomMVCIdentity;
using CustomMVCIdentity.App_Start;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Startup))]
namespace CustomMVCIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //private void ConfigureAuth(IAppBuilder app)
        //{
        //  //  throw new NotImplementedException();
        //}
    }
}
