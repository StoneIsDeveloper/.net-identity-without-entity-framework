using System;
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
    }
}
