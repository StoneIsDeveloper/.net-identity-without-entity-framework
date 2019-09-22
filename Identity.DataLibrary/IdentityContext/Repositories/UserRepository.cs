using Dapper;
using Identity.DataLibrary.Core;
using Identity.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DataLibrary.IdentityContext.Repositories
{
    public class UserRepository 
    {
        public UserRepository() 
        {
        }

        public static User GetUser(int id)
        {
            List<ParameterInfo> parameters = new List<ParameterInfo>();
            parameters.Add(new ParameterInfo() { ParameterName = "ID", ParameterValue = id });
            var spName = "dbo.GetUserByID";
            User oUser = SqlHelper.GetRecord<User>(spName, parameters);
            return oUser;
        }
        public static User GetUser(string email)
        {
            List<ParameterInfo> parameters = new List<ParameterInfo>();
            parameters.Add(new ParameterInfo() { ParameterName = "Email", ParameterValue = email });
            var spName = "dbo.GetUserByEmail";
            User oUser = SqlHelper.GetRecord<User>(spName, parameters);
            return oUser;
        }

        public static User GetUserByName(string userName)
        {
            List<ParameterInfo> parameters = new List<ParameterInfo>();
            parameters.Add(new ParameterInfo() { ParameterName = "UserName", ParameterValue = userName });
            var spName = "dbo.GetUserByUserName";
            User oUser = SqlHelper.GetRecord<User>(spName, parameters);
            return oUser;
        }

        public static User CreateUser(User user)
        {          
            DynamicParameters parameters = new DynamicParameters();
            #region parameters
            parameters.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            parameters.Add("@UserName", user.Username);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            parameters.Add("@Status", user.Status);
            parameters.Add("@Active", user.Active);
            parameters.Add("@Deleted", user.Deleted);
            parameters.Add("@EmailVerified", user.EmailVerified);
            parameters.Add("@FisrtName", user.Firstname);
            parameters.Add("@LastName", user.Lastname);
            parameters.Add("@Phone", user.Phone);
            parameters.Add("@PhoneVerified", user.PhoneVerified);
            parameters.Add("@ProfilePic", user.ProfilePic);
            parameters.Add("@SecurityStamp", user.SecurityStamp);
            #endregion 
            var spName = "dbo.InsertUser";
            var userID = 0;
            using (SqlConnection conn = new SqlConnection(Util.ConnectionString))
            {
                conn.Open();
                var row = SqlMapper.Execute(conn, spName, parameters, commandType: CommandType.StoredProcedure);
                userID = parameters.Get<Int32>("@ID");
                conn.Close();
            }
            user.Id = userID;

            return user;
        }

        public static User UpdateUser(User user)
        {
            return user;
        }

        public static IEnumerable<User> GetAllUsers()
        {
            var sql = @"select u.*, r.* 
                        from dbo.Users u
                        left join dbo.UserRoles a on a.UserID = u.Id
                        left join dbo.Roles r on a.RoleID = r.Id";
            using (var conn = new SqlConnection(Util.ConnectionString))
            {
                conn.Open();
                var lookup = new Dictionary<int, User>();
                var list = conn.Query<User, Role, User>(sql, (appUser, role) =>
                {
                    User userEntity;
                    if (!lookup.TryGetValue(appUser.Id, out userEntity))
                    {
                        userEntity = appUser;
                        lookup.Add(appUser.Id, userEntity);
                    }
                    if (userEntity.Roles == null)
                    {
                        userEntity.Roles = new List<Role>();
                    }
                       
                    if(role!= null)
                    {
                        if (!userEntity.Roles.Any(x => x.Id == role.Id))
                        {
                            userEntity.Roles.Add(role);
                        }
                    }
                       

                    return appUser;
                }, splitOn: "Id").ToList();

                conn.Close();
                return lookup.Values.ToList();

            }

        }

        public static IEnumerable<User> GetUserAddress()
        {
            var sql = @"select u.*,a.* 
                        from  dbo.Users u
                        left join dbo.Address a on a.UserID = U.Id";
            using (var conn = new SqlConnection(Util.ConnectionString))
            {
                conn.Open();
                var myUsers = new Dictionary<int, User>();

                conn.Query<User, Address, User>(sql, (appUser, address) =>
                {
                    User userEntity;
                    if(!myUsers.TryGetValue(appUser.Id,out userEntity))
                    {
                        myUsers.Add(appUser.Id, userEntity = appUser);
                    }
                    // Address
                    if(userEntity.Addresses == null)
                    {
                        userEntity.Addresses = new List<Address>();
                    }
                    if(address != null)
                    {
                        if(!userEntity.Addresses.Any(x=> x.AddressId == address.AddressId))
                        {
                            userEntity.Addresses.Add(address);
                        }
                    }
                    return userEntity;

                }, splitOn: "AddressId");
                conn.Close();

                return myUsers.Values.ToList();
            }

        }

    }
}
