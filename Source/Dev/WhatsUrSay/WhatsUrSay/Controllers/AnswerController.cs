/*
Component :                             A Web Api controller that invokes the methods defined in 'AnswerRepo.cs' to serve the client requests in performing 'insert' and 'read' operations on the 'Answer' table of our project's database (DSE)
Author:                                 Nikhitha Kaza
Use of the component in system design:  Serves the requests of the clients
Written and revised:                    11/5/2016
Reason for component existence:         To serve the requests of the clients in performing 'insert' and 'read' operations on the 'Answer' table
Component usage of data structures, algorithms and control(if any):
    The component contains the below methods:
        GetAnswers(), PostSurvey(Answer Act)
    These methods are invoked by the clients upon their request for a particular service on 'Answer' table
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//It includes all the models from the WhatsUrSay
using WhatsUrSay.Models;
using WhatsUrSay.Interfaces;
using System.Web.Http.Description;
using WhatsUrSay.DTO;

namespace WhatsUrSay.Controllers
{
    public class AnswerController : ApiController
    {
        //  It reads the IAnswer interface.
         AnswerResp Answer1 = new AnswerResp();
        public AnswerController() { }

        //GETAnswers api/<controller>
        //Purpose: Invokes 'GetAnswers()' method of AnswerRepo.cs that returns all the records of type 'answer' from the 'Answer' table
        //Input: None
        //Output: A list of answer records from the 'Answer' table
        public IEnumerable<Answer> GetAnswers()
        {
            return Answer1.GetAll();
        }

        public IQueryable<AnswerDTO> GetAnswersForCount(int id)
        {
            return Answer1.GetAnswersForCount(id);
        }

        //PostSurvey api/<controller>
        //Purpose: Invokes 'PostSurvey(Answer Act) method of 'AnswerRepo.cs' that adds an object 'answer' in the 'Answer' table
        //Input: 'activity' object of type 'Answer.cs'
        //Output: Returns the object 'answer' upon its successful addition in the table
        public Answer PostSurvey(Answer Act)
        {
            return Answer1.Add(Act);
        }

     
        [ResponseType(typeof(void))]
        public IHttpActionResult PostSurveyAnswers(UserAnswersList UserAnswers)
        {
            try
            {
                foreach (var answer in UserAnswers.Answers)
                {
                    Answer1.Update(answer, UserAnswers.UserId);
                }
            }

            catch
            {
                StatusCode(HttpStatusCode.InternalServerError);
            }
            return StatusCode(HttpStatusCode.OK);
        }

    }
}
