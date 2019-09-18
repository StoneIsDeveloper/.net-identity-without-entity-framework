using Identity.ApiLibrary;
using Identity.ModelsLibrary;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IdentityLibrary
{
    public class MyUserStore : IUserStore<MyUser, string>,
        IUserLoginStore<MyUser, string>,
        IUserRoleStore<MyUser, string>
    {
        private readonly AuthApi _userService;

        public MyUserStore(AppUserInfo appUserInfo)
        {
            _userService = new AuthApi(appUserInfo);
        }

        public Task AddLoginAsync(MyUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(MyUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<MyUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<MyUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<MyUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(MyUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(MyUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(MyUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MyUser user)
        {
            throw new NotImplementedException();
        }
    }
}
