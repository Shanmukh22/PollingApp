using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using WhatsUrSay.Controllers;
using WhatsUrSay.Models;
using WhatsUrSay.Repositories;

namespace WhatsUrSay.Tests
{
    [TestClass]
    public class TestUserController
    {

        [TestMethod]
      
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            var testUser = GetTestUser();
            var controller = new UserController(testUser);

            var result = controller.GetUsers().ToList<User>();
            Assert.IsNotNull(result);
        }


     /*   public void GetUserWithId_ShouldReturnCorrectUser()
        {
            var testUser = GetTestUser();
            var controller = new UserController(testUser);

            var result = controller.Get("raj") as List<User>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testUser[1].emailId, result.emailId);
        }*/


        private List<User> GetTestUser()
        {
            var testUser = new List<User>();
            testUser.Add ( new User { id = 1, name = "raj", emailId = "raj@gmail.com", pwd = "Raj1", status = "active" } );
            return testUser;
        }
    }
}
