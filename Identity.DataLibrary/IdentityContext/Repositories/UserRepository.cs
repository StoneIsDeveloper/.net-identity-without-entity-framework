using Dapper;
using Identity.DataLibrary.Core;
using Identity.DataLibrary.Models;
using IdentityManagement.Data;
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

        //public User GetUser(int userId)
        //{
        //    return _context.Users.Include(u => u.UserRole).FirstOrDefault(u => u.Id == userId);            
        //}
        public static User GetUser(string id)
        {
            List<ParameterInfo> parameters = new List<ParameterInfo>();
            parameters.Add(new ParameterInfo() { ParameterName = "Id", ParameterValue = id });
            User oUser = SqlHelper.GetRecord<User>("GetUser", parameters);
            return oUser;
        }

        public static User GetUserByName(string userName)
        {
            List<ParameterInfo> parameters = new List<ParameterInfo>();
            parameters.Add(new ParameterInfo() { ParameterName = "UserName", ParameterValue = userName });
            User oUser = SqlHelper.GetRecord<User>("GetUser", parameters);
            return oUser;
        }

        public static User CreateUser(User user)
        {          
            DynamicParameters parameters = new DynamicParameters();

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
    }
}
