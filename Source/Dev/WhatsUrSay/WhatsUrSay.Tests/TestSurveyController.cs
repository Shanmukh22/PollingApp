


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using WhatsUrSay.Controllers;
//using System.Threading.Tasks;
using WhatsUrSay.Models;
using System.Web.Http.Results;

namespace WhatsUrSay.Tests
{
    [TestClass]
    public class TestSurveyController
    {
        [TestMethod]
        public void GetAllsurveys_ShouldReturnAllsurveys()
        {
            var testSurvey = GetTestSurvey();
            var controller = new SurveyController(testSurvey);

            var result = controller.GetAllSurveys() as List<Activity>;
            Assert.AreEqual(testSurvey.Count, result.Count);
        }



        [TestMethod]
        public void GetSurvey_ShouldReturnCorrectSurvey()
        {
            var testSurvey = GetTestSurvey();
            var controller = new SurveyController(testSurvey);

            var result = controller.GetSurvey(3);
            Assert.IsNotNull(result);
            Assert.AreEqual(testSurvey[0].heading, result.heading);
        }

        [TestMethod]
        public void Getsurvey_ShouldNotFindsurvey()
        {
            var controller = new SurveyController(GetTestSurvey());

            var result = controller.GetSurvey(3);
            Assert.IsInstanceOfType(result, typeof(Activity));
        }

        private List<Activity> GetTestSurvey()
        {
            var testActivity = new List<Activity>();
            testActivity.Add(new Activity { id = 3, heading = "Professor Feedback", description = "SE Professor feedback", type = 1, category = 2, createdby = 1, results_published = null });
            return testActivity;
        }
    }
}