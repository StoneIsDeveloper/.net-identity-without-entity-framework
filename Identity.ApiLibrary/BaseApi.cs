using Identity.ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.ApiLibrary
{
    public abstract class BaseApi
    {
        protected readonly AppUserInfo AppUserInfo;
        protected BaseApi()
        {
        }

        protected BaseApi(AppUserInfo appUserInfo)
        {
            AppUserInfo = appUserInfo;
        }

    }
}
