/*
Component :                             A class that does CRUD operations on the 'Answer' table of our project's database (DSE)
Author:                                 Nikhitha Kaza
Use of the component in system design:  Used for performing CRUD operations on the 'Answer' table
Written and revised:                    11/5/2016
Reason for component existence:         To perform CRUD operations on the 'Answer' table
Component usage of data structures, algorithms and control(if any):
    The component contains the below methods:
         GetAll(), Get(int id), Add(Answer Ans), Update(Answer Ans), Delete(int id)
    These methods are invoked by 'AnswerController', a Web Api controller that serves the clients' requests
*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
//includes all the models from the WhatsUrSay
using WhatsUrSay.Models;
using WhatsUrSay.DTO;

namespace WhatsUrSay
{
    public class AnswerResp: IAnswer
    {
        DSEEntities Db2 = new DSEEntities();

        //Purpose: Gets all the records of type 'answer' from the 'Answer' table
        //Input: None
        //Output: A list of answer records from the 'Answer' table
        public IEnumerable<Answer> GetAll()
        {
            // TO DO : Code to get the list of all the records in database
            return Db2.Answers;
        }


        public IQueryable<AnswerDTO> GetAnswersForCount(int activityId)
        {
            var answer = from b in Db2.Answers
                         where (b.activity_id == activityId)
                         select new AnswerDTO()
                         {
                             id = b.id,
                             description = b.description,
                             question_id = b.question_id,
                             count = (int)b.count
                         };
            return answer;
        }

        //Purpose: Gets a record from the 'Answer' table whose row id is 'id'
        //Input: 'id' of the required record
        //Output: a record from 'Answer' table whose key is 'id'
        public Answer Get(int id)
        {
            // TO DO : Code to find a record in database
            return Db2.Answers.Find(id);
        }

        //Purpose: Adds an object 'answer' in the 'Answer' table
        //Input: 'answer' object of type 'Answer.cs'
        //Output: Returns the object 'answer' upon its successful addition in the table
        public Answer Add(Answer Ans)
        {
            if (Ans == null)
            {
                throw new ArgumentNullException("Answer");
            }

            // TO DO : Code to save record into database
            Db2.Answers.Add(Ans);
           
            Db2.SaveChanges();
            return Ans;
        }

    
        public bool Update(Answer Ans,int userId)
        {
            if (Ans == null)
            {
                throw new ArgumentNullException("Answer");
            }

            // TO DO : Code to save record into database
            try
            {
                Db2.Entry(Ans).State = EntityState.Modified;
                Db2.User_Answer.Add(new User_Answer() { activity_id = Ans.activity_id, question_id = Ans.question_id, user_id = userId, answer_id = Ans.id });
                Db2.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                throw ex;
            }
            return true;
        }
       
    }
}