﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.DataLibrary.IdentityContext;
using Identity.DataLibrary.IdentityContext.Repositories;
using Identity.ModelsLibrary;
using Identity.ModelsLibrary.Records.Identities;
using DataUser = Identity.DataLibrary.Models.User;
using User = Identity.ModelsLibrary.User;

namespace Identity.ApiLibrary
{
    public class AuthApi : BaseApi, IDisposable
    {
        public AuthApi()
        {
        }
        public AuthApi(AppUserInfo appUserInfo) : base(appUserInfo)
        {
        } 

        #region User
        public User GetUser(int userId)
        {
            var user = UserRepository.GetUser(userId);
            return MapUser(user);
        }

        public User GetUser(string email)
        {
            var user = UserRepository.GetUser(email);
            return MapUser(user);
        }

        public User GetUserByName(string username)
        {
            return MapUser(UserRepository.GetUserByName(username));
        }

        public User CreateUser(User userEntity)
        {
            var userRecord = MapUser(userEntity, false);
            UserRepository.CreateUser(userRecord);
            return MapUser(userRecord);
        }
        #endregion

        #region Password
        public string GetUserPasswordHash(int userId)
        {
            var user = UserRepository.GetUser(userId);
            return MapUser(user).Password;
        }

        public void SetUserPasswordHash(int userId,string passwordHash)
        {
            var userRecord = UserRepository.GetUser(userId);
            userRecord.Password = passwordHash;
            UserRepository.UpdateUser(userRecord);
        }
        #endregion

        #region Email
        public string GetUserEmail(int userId)
        {
            var user = UserRepository.GetUser(userId);
            return MapUser(user).UserName;
        }

        public bool GetUserEmailVerified(int userId)
        {
            var user = UserRepository.GetUser(userId);
            return MapUser(user).EmailVerified;
        }

        public void SetUserEmail(int userId, string email)
        {
            var userRecord = UserRepository.GetUser(userId);
            userRecord.Username = email;

           // _unitOfWork.Complete();
            UserRepository.UpdateUser(userRecord);
        }
        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private DataUser MapUser(User user, bool mapId = true)
        {
            if (user == null) return null;
            return new DataUser()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                EmailVerified = user.EmailVerified,
                Id = mapId && IsValidInt(user.Id) ? int.Parse(user.Id) : int.Parse("0"),
                Password = user.Password,
                Phone = user.Phone,
                PhoneVerified = user.PhoneVerified,
                SecurityStamp = user.SecurityStamp,
                Username = user.UserName,
                Email = user.Email,
                Active = user.Active,
                CreatedOnDate = user.CreatedOn,
                Deleted = user.Deleted,
                ProfilePic = user.ProfilePic
            };
        }

        private User MapUser(DataUser user, bool mapId = true)
        {
            if (user == null) return null;
            return new User()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                EmailVerified = user.EmailVerified,
                Id = mapId ? user.Id.ToString() : "0",
                Password = user.Password,
                Phone = user.Phone,
                PhoneVerified = user.PhoneVerified,
                SecurityStamp = user.SecurityStamp,
                UserName = user.Username,
                Email = user.Email,
                Active = user.Active,
                CreatedOn = user.CreatedOnDate,
                Deleted = user.Deleted,
                ProfilePic = user.ProfilePic,
                //UserRoles = user.UserRole.Select(r => new RecordIdentity() { Id = r.Role.Id, Name = r.Role.Name }).ToList(),
                //Roles = user.UserRole.Select(r => r.Role.Name).ToList()
            };
        }


        private bool IsValidInt(string input)
        {
            int output;
            return int.TryParse(input, out output);
        }
    }
}
