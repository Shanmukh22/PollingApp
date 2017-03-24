using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUrSay.Controllers;
using WhatsUrSay.Models;

namespace WhatsUrSay.Tests
{
    [TestClass]
    public class TestGroupController
    {

        [TestMethod]
        public void GetAllGroups_ShouldReturnAllGroups()
        {
            var testGroup = GetTestGroup();
            var controller = new GroupsController(testGroup);

            var result = controller.GetGroups() as DbQuery<Group>;
            Assert.AreEqual(testGroup.Count, result.Count());
        }

        private List<Group> GetTestGroup()
        {
            var testGroup = new List<Group>();
            testGroup.Add(new Group { id = 1, name="se team",createdby=1 });
            return testGroup;
        }

    }
}
