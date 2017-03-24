/*
Component :                             A class that does CRUD operations on the 'Activity' table of our project's database (DSE)
Author:                                 Nikhitha Kaza
Use of the component in system design:  Used for performing CRUD operations on the 'Activity' table
Written and revised:                    11/5/2016
Reason for component existence:         To perform CRUD operations on the 'Activity' table
Component usage of data structures, algorithms and control(if any):
    Uses Entity framework class 'Activity.cs' to do CRUD operations on 'Activity' table
    The component contains the below methods:
        'GetAll()', 'Get(int id)', 'Add(Activity activity)', 'Update(Activity activity)', 'Delete(int id)'
    These methods are invoked by 'SurveyController', a Web Api controller that serves the clients' requests
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;
using System.Data.Entity;

namespace WhatsUrSay
{
    public class SurveyResp : ISurvey
    {
        DSEEntities Db1 = new DSEEntities();

        //Purpose: Gets all the records of type 'poll' from the 'Activity' table
        //Input: None
        //Output: A list of poll records from the 'Activity' table
        public IEnumerable<Activity> GetAll()
        {
            //Db1.Configuration.LazyLoadingEnabled = false;
            // TO DO : Code to get the list of all the records in database
            var activities = Db1.Activities.ToList();
            foreach (var act in activities)
            {
                act.Questions = Db1.Questions.Where(ques => ques.activity_id == act.id).ToList();
                foreach (var question in act.Questions)
                {
                    act.Answers = Db1.Answers.Where(ans => ans.question_id == question.id && ans.activity_id == act.id).ToList();
                }
            }
            return Db1.Activities.Where(e => e.category == 2);
        }


        //Purpose: Gets a record from the 'Activity' table whose row id is 'id'
        //Input: 'id' of the required record
        //Output: a record from 'Activity' table whose key is 'id'
        public Activity Get(int id)
        {
            // TO DO : Code to find a record in database
            return Db1.Activities.Find(id);
        }



        //Purpose: Adds an object 'activity' in the 'Activity' table
        //Input: 'activity' object of type 'Activity.cs'
        //Output: Returns the object 'activity' upon its successful addition in the table
        public Activity Add(Activity Act)
        {
            if (Act == null)
            {
                throw new ArgumentNullException("Activity");
            }

            // TO DO : Code to save record into database
            Db1.Activities.Add(Act);
            foreach (var question in Act.Questions)
            {
                question.activity_id = Act.id;
                Db1.Questions.Add(question);
                foreach (var answer in question.Answers)
                {
                    answer.question_id = question.id;
                    answer.activity_id = question.activity_id;
                    Db1.Answers.Add(answer);

                }

            }
            if (Act.Activity_Group != null)
            {
                foreach (var group in Act.Activity_Group)
                {
                    group.activity_id = Act.id;
                    Db1.Activity_Group.Add(group);
                }
            }
            Db1.SaveChanges();
            return Act;
        }

        //Purpose: Updates the row whose key is updated.id with the details of object 'updated' in the 'Activity' table
        //Input: 'updated' object of type 'Activity.cs'
        //Output: Returns 'true' upon the successful updation of record in the table
        //        In case of 'null' input, the method throws 'ArgumentNullException'
        public bool Update(Activity Act)
        {
            if (Act == null)
            {
                throw new ArgumentNullException("Activity");
            }

            // TO DO : Code to update record into database
            var Survey1 = Db1.Activities.Single(a => a.id == Act.id);
            Survey1.heading = Act.heading;
            Survey1.description = Act.description;
            Survey1.type = Act.type;
            Survey1.category = Act.category;
            // Survey1.group_ids = Act.group_ids;
            Db1.SaveChanges();

            return true;
        }

        //Purpose: Deletes the row whose key 'id' in the 'Activity' table
        //Input: 'id' of the activity that needs to be deleted
        //Output: Returns 'true' upon the successful deletion of record from the table
        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            Activity products = Db1.Activities.Find(id);
            Db1.Activities.Remove(products);
            Db1.SaveChanges();
            return true;
        }


    }
}