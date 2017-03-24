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
    class TestQuestionController
    {
        public void PostQuestiControlleron_ShouldPostQuestions()
        {
            var testQuestion = GetTestQuestions();
            var controller = new QuestionController(testQuestion);

            var result = controller.PostQuestion() as List<Question>;
            Assert.AreEqual(testQuestion.Count, result.Count);
        }
        private List<Question> GetTestQuestions()
        {
            var testActivity = new List<Question>();
            testActivity.Add(new Question { id = 1, description = "ClassNeeded", activity_id=1});
      

            return testActivity;
        }

    }
}
