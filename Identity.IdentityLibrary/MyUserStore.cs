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

        #region IUserStore
        public Task CreateAsync(MyUser user)
        {
            var userEntity = new User()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Phone = user.Phone,
                UserName = user.UserName,
                Password = user.Password,
                Active = user.Active,
                SecurityStamp = user.SecurityStamp,
                EmailVerified = false,
                PhoneVerified = false,
                CreatedOn = DateTime.Now,
                Deleted = false
            };
            _userService.CreateUser(userEntity);

            throw new NotImplementedException();
        }

        public Task DeleteAsync(MyUser user)
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
        public Task UpdateAsync(MyUser user)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserLoginStore
        public Task AddLoginAsync(MyUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }
        public Task<MyUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }
        public Task<IList<UserLoginInfo>> GetLoginsAsync(MyUser user)
        {
            throw new NotImplementedException();
        }
        public Task RemoveLoginAsync(MyUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserRoleStore
        public Task AddToRoleAsync(MyUser user, string roleName)
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
        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        
    
    }
}
