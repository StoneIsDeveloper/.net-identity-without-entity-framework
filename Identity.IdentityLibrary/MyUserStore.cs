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

            return Task.FromResult(0);
        }

        public Task DeleteAsync(MyUser user)
        {
            //User should not delete itself
            return Task.FromResult(0);
        }
        public Task<MyUser> FindByIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return Task.FromResult(default(MyUser));
            }

            var id = int.Parse(userId);
            var userRequest = _userService.GetUser(id);
            return Task.FromResult(userRequest != null ? MappUser(userRequest) : default(MyUser));
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

        public static MyUser MappUser(User record)
        {
            var result = new MyUser()
            {
                Id = record.Id,
                Firstname = record.Firstname,
                Lastname = record.Lastname,
                Phone = record.Phone,
                UserName = record.UserName,
                Password = record.Password,
                Active = record.Active,
                SecurityStamp = record.SecurityStamp,
                EmailVerified = record.EmailVerified,
                PhoneVerified = record.PhoneVerified,
                CreatedOn = record.CreatedOn,
                Deleted = record.Deleted,
                Roles = record.UserRoles.Select(r => r.Name).Distinct().ToList(),
            };

            return result;
        }


    }
}
