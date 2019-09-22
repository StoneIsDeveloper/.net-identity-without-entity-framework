using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Identity.DataLibrary.IdentityContext.Repositories;
using Identity.DataLibrary.Models;
using IdentityManagement.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var password = "hellowworld";
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var hashedPassword2 = "$2a$10$fD8CEPQ3lIjVQb.2aS4prOeW9cKsQOrzeaSw/MCTmJBtdqja/M61C";
            var hashedPassword3 = "$2a$10$fD8CEPQ3lIjVQb.2aS4prOeW9cKsQOrzeaSw/MCTmJBtdqja/M61C";

            var passwordMatched2 = BCrypt.Net.BCrypt.Verify(password, hashedPassword2);
            var passwordMatched3 = BCrypt.Net.BCrypt.Verify(password, hashedPassword3);
        }

        [TestMethod]
        public void TestStoredProcedure()
        {
            List<ParameterInfo> parameters = new List<ParameterInfo>();
            parameters.Add(new ParameterInfo() { ParameterName = "Id", ParameterValue = 1 });
            var spName = "[dbo].[InsertLogAndReturnID]";

            using (SqlConnection objConnection = new SqlConnection(Util.ConnectionString))
            {
                objConnection.Open();
                DynamicParameters p = new DynamicParameters();

                p.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@TypeID", 1);
                p.Add("@Description", "TEST1");
                p.Add("@UserName", "stone");

                var row = SqlMapper.Execute(objConnection, spName, p, commandType: CommandType.StoredProcedure);
                var id  = p.Get<Int32>("@ID");

                objConnection.Close();
            }
        }

        [TestMethod]
        public void InsertUser()
        {
            var user = new User() {
                Username = "abc",
                Email = "afdsf",
                Password = "fdsfpassss",
                Status = EnumUserStatus.Active,
                Active = true,
                Deleted = false,
                EmailVerified = false,
                Firstname = "Tom",
                Lastname = "Jack",
                Phone ="123456",
                PhoneVerified = false,
                ProfilePic = "123",
                SecurityStamp = DateTime.Now.ToString()
            };
            UserRepository.CreateUser(user);

            var userId = user.Id;

        }

        [TestMethod]
        public void GetAllUsers()
        {
           // var users = UserRepository.GetAllUsers().AsList();

            var userAddress = UserRepository.GetUserAddress().AsList();
        }
    }
}
