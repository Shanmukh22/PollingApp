using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUrSay.Controllers;
using WhatsUrSay.DTO;
using WhatsUrSay.Models;

namespace WhatsUrSay.Tests
{
    [TestClass]
    public class TestAnswerController
    {

        [TestMethod]
        public void GetAllAnswers_ShouldReturnAllAnswers()
        {
            var testAnswer= GetTestAnswer();
            var controller = new AnswerController();

            var result = controller.GetAnswers().ToList<Answer>();
            Assert.IsNotNull(result);
        }


/*
        [TestMethod]
        public void GetAnswer_ShouldReturnCountForThatAnswerSelected()
        {
            var testAnswer = GetTestAnswer();
            var controller = new AnswerController();

            var result = controller.GetAnswersForCount(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result);
        }
        */
    
        private List<Answer> GetTestAnswer()
        {
            var testAnswer = new List<Answer>();
            testAnswer.Add(new Answer { id = 7, description= "yes", question_id=3, count=0 });
          
            return testAnswer;
        }
    }
}
