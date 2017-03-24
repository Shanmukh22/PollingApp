/*
Component :                             A Web Api controller that invokes the methods defined in 'SurveyRepo.cs' to serve the client requests in performing 'insert' and 'read' operations on the 'Activity' table of our project's database (DSE)
Author:                                 Nikhitha Kaza
Use of the component in system design:  Serves the requests of the clients
Written and revised:                    11/5/2016
Reason for component existence:         To serve the requests of the clients in performing 'insert' and 'read' operations on the 'Activity' table
Component usage of data structures, algorithms and control(if any):
    The component contains the below methods:
        GetAllSurveys(), PostSurvey(Activity Act)
    These methods are invoked by the clients upon their request for a particular service on 'Activity' table
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Models;

namespace WhatsUrSay.Controllers
{
    public class SurveyController : ApiController
    {
        //It reads the  Isuvery interface
        static readonly ISurvey Survey1 = new SurveyResp();
        private List<Activity> list;

        public SurveyController() { }
        public SurveyController(List<Activity> list)
        {
            this.list = list;
        }

        //GetAllSurveys api/<controller>
        //Purpose: Invokes 'GetAllSurveys()' method of SurveyRepo.cs that returns all the records of type 'survey' from the 'Survey' table
        //Input: None
        //Output: A list of answer records from the 'Survey' table
        public IEnumerable<Activity> GetAllSurveys()
        {
            return Survey1.GetAll();
        }

        /// <summary>
        /// Return Activity for given activity Id
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public Activity GetSurvey([FromUri]int activityId)
        {
            Activity activity = Survey1.GetAll().First(e => e.id == activityId);
            return activity;
        }

        //PostSurvey api/<controller>
        //Purpose: Invokes 'PostSurvey(Activity Act) method of 'ActivityRepo.cs' that adds an object 'activity' in the 'Activity' table
        //Input: 'activity' object of type 'Activity.cs'
        //Output: Returns the object 'activity' upon its successful addition in the table
        public Activity PostSurvey(Activity newSurvey)
        {
            return Survey1.Add(newSurvey);
        }
    }
}
