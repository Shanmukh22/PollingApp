﻿/*
Component :                             A class that does 'read' operations on the 'Activity' table of our project's database (DSE)
Author:                                 Sreedevi Koppula
Use of the component in system design:  Used for performing 'read' operations on the 'Activity' table 
Written and revised:                    11/25/2016
Reason for component existence:         To perform 'read' operations on the 'Activity' table 
Component usage of data structures, algorithms and control(if any): 
    Uses Entity framework class 'Activity.cs' to do 'read' operations on 'Activity' table
    The component contains the below methods:
        'GetPolls()', 'GetPoll(int id)'
    These methods are invoked by 'ActivityDTOController.cs', a Web Api controller that serves the clients' requests
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.DTO;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class ActivityDTORespository
    {
        private DSEEntities db = new DSEEntities();

        //Purpose: Returns all the records of type 'poll' from the 'Activity' table
        //Input: None
        //Output: A list of poll records from the 'Activity' table
        public IQueryable<ActivityDTO> GetPolls()
        {
            var polls = from b in db.Activities
                        select new ActivityDTO()
                        {
                            heading = b.heading,
                            description = b.description,
                            questionId = b.Questions.FirstOrDefault().id,
                            question = b.Questions.FirstOrDefault().description,
                            options = (HashSet<string>)b.Answers.Select(x => x.description)
                        };
            return polls;
        }

        //Purpose: Returns a record from the 'Activity' table whose key is 'id'
        //Input: 'id' of the required record
        //Output: a record from 'Activity' table whose key is 'id's
        public IQueryable<ActivityDTO> GetPoll(int id)
        {
            var poll = from b in db.Activities
                       where (b.id == id)
                       select new ActivityDTO()
                       {
                           heading = b.heading,
                           description = b.description,
                           questionId = b.Questions.FirstOrDefault().id,
                           question = b.Questions.FirstOrDefault().description,
                           options = (HashSet<string>)b.Answers.Select(x => x.description)
                       };
            return poll;
        }


    }
}