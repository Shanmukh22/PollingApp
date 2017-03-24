
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Linq;
//using System.Text;
using WhatsUrSay.Controllers;
//using System.Threading.Tasks;
using WhatsUrSay.Models;
using System.Web.Http.Results;
using System.Data.Entity.Infrastructure;
using WhatsUrSay.DTO;

namespace WhatsUrSay.Tests
{
    [TestClass]
    public class TestPollController
    {
        [TestMethod]
        public void GetAllPoll_ShouldReturnAllPoll()
        {
            var testPoll = GetTestPoll();
            var controller = new PollController(testPoll);

            var result = controller.GetAllPolls() as DbQuery<ActivityDTO>;
            Assert.AreEqual(testPoll.Count, result.Count());
        }


      /*    [TestMethod]
            public void GetPoll_ShouldReturnCorrectPoll()
            {
                var testPoll = GetTestPoll();
                var controller = new PollController(testPoll);

                var result = controller.GetPoll(2);
                Assert.IsNotNull(result);
                Assert.AreEqual(testPoll[0].heading, result[0].heading);
            }*/
     
        [TestMethod]
        public void GetPoll_ShouldReturnCorrectPoll()
        {
            var controller = new PollController(GetTestPoll());

            var result = controller.GetPoll(2);
            Assert.IsInstanceOfType(result, typeof(DbQuery<ActivityDTO>));
        }

        private List<Activity> GetTestPoll()
        {
            var testActivity = new List<Activity>();
            testActivity.Add(new Activity { id = 2, heading = "ExamPattern", description = "FinalExamPatternForSe", type = 1, category = 1, createdby = 1, results_published = null });
            testActivity.Add(new Activity { id = 1, heading = "DoYouWantClass", description = "IsSoftwareEngineeringClassRequiredon20th", type = 1, category = 1, createdby = 1, results_published = null });

            return testActivity;
        }
    }
}