/*
Component :                             A Web Api controller that invokes the methods defined in 'QuestionRepository.cs' to serve the client requests in performing 'insert' operation on the 'Question' table of our project's database (DSE)
Author:                                 Sreedevi Koppula
Use of the component in system design:  Serves the requests of the clients 
Written and revised:                    11/5/2016
Reason for component existence:         To serve requests of the clients in performing 'insert' operation on the 'Question' table 
Component usage of data structures, algorithms and control(if any): 
    The component contains the below methods:
        'PostQuestion(Question question)'
    This method is invoked by the clients upon their request for service to add a question in the 'Question' table
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Repositories;
using WhatsUrSay.Models;

namespace WhatsUrSay.Controllers
{
    public class QuestionController : ApiController
    {
        QuestionRepository repo = new QuestionRepository();

        //Purpose: Invokes 'Add(Question question)' method of 'QuestionRepository.cs' that adds an object 'question' in the 'Question' table
        //Input: 'question' object of type 'Question.cs'
        //Output: Returns the object 'question' upon its successful addition in the table
        public Question PostQuestion(Question question)
        {
            return repo.Add(question);
        } 
    }
}
