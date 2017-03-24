using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUrSay.Controllers;
using WhatsUrSay.Models;

namespace WhatsUrSay.Tests
{
    [TestClass]
    public class TestLoginController
    {
        [TestMethod]

        public void TestLogin_Controller()
        {
            var testLogin = GetTestLogin();
            var controller = new LoginController(testLogin);
            UserLoginInput user = new UserLoginInput();
            user.uName = testLogin[0].name;
            user.uPassword = testLogin[0].pwd;
            var result = controller.Login(user);
            Assert.IsNull(result);
        }
        private List<User> GetTestLogin()
        {
            var testUser = new List<User>();
            testUser.Add(new User { id = 1, name = "raj", emailId = "raj@gmail.com", pwd = "Raj1", status = "active" });
            return testUser;
        }
    }
}
