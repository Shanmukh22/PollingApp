/*
Component :                             A Web Api controller that invokes the methods defined in 'PollRepository.cs' to serve the client requests in performing 'insert' and 'read' operations on the 'Activity' table of our project's database (DSE)
Author:                                 Sreedevi Koppula
Use of the component in system design:  Serves the requests of the clients
Written and revised:                    11/25/2016
Reason for component existence:         To serve the requests of the clients in performing 'insert' and 'read' operations on the 'Activity' table 
Component usage of data structures, algorithms and control(if any): 
    The component contains the below methods:
        'GetAllPolls()', 'GetPoll(int id)', 'PostPoll(Activity activity)'
    These methods are invoked by the clients upon their request for a particular service on 'Activity' table
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Models;
using WhatsUrSay.Repositories;
using WhatsUrSay.DTO;

namespace WhatsUrSay.Controllers
{
    public class PollController : ApiController
    {
        PollRepository repo = new PollRepository();

        //Purpose: Invokes 'GetAll()' method of PollRepository.cs that returns all the records of type 'poll' from the 'Activity' table
        //Input: None
        //Output: A list of poll records from the 'Activity' table
        public IQueryable<ActivityDTO> GetAllPolls()
        {
            try
            {
                return repo.GetPolls();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Purpose: Invokes 'Get(int id)' method of PollRepository.cs that returns a record from the 'Activity' table whose key is 'id'
        //Input: 'id' of the required record
        //Output: a record from 'Activity' table whose key is 'id'
        public IQueryable<ActivityDTO> GetPoll(int id)
        {
            try
            {
                return repo.GetPoll(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Purpose: Invokes 'Add(Activity activity) method of 'PollRepository.cs' that adds an object 'activity' in the 'Activity' table
        //Input: 'activity' object of type 'Activity.cs'
        //Output: Returns the object 'activity' upon its successful addition in the table
        public Activity PostPoll(ActivityGroupDetails activity)
        {
            try
            {
                return repo.Add(activity);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
