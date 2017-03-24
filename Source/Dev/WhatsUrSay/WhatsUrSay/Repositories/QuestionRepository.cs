/*
Component :                             A class that does 'insert' operation on the 'Question' table of our project's database (DSE)
Author:                                 Sreedevi Koppula
Use of the component in system design:  Used for performing 'insert' operation on the 'Question' table 
Written and revised:                    11/5/2016
Reason for component existence:         To perform 'insert' operation on the 'Question' table 
Component usage of data structures, algorithms and control(if any): 
    Uses Entity framework class 'Question.cs' to do 'insert' operation on 'Question' table
    The component contains the below method:
        'Add(Question question)' 
    These methods are invoked by 'QuestionController', a Web Api controller that serve the clients' requests
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class QuestionRepository
    {
        private DSEEntities db = new DSEEntities();

        //Purpose: Adds an object 'question' in the 'Question' table
        //Input: 'question' object of type 'Question.cs'
        //Output: Returns the object 'question' upon its successful addition in the table
        //        If any exception occurs, the exception message is printed and the exception is thrown
        public Question Add(Question question)
        {
            if (question == null)
                throw new ArgumentNullException("question");

            try
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return question;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
                throw e;
            }
        }
    }
}