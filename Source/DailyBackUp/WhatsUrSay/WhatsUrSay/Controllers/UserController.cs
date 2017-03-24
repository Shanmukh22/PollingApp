/*
Component :                             A Web Api controller that invokes the methods defined in 'UserRepository.cs' to serve the client requests in performing 'insert' and 'read' operations on the 'User' table of our project's database (DSE)
Author:                                 Abhinav Bhandaram
Use of the component in system design:  Serves the requests of the clients
Written and revised:                    11/5/2016
Reason for component existence:         To serve the requests of the clients in performing 'insert' and 'read' operations on the 'User' table
Component usage of data structures, algorithms and control(if any):
    The component contains the below methods:
         Get(),  Get(string uName), Post([FromBody]User user)
    These methods are invoked by the clients upon their request for a particular service on 'User' table
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Repositories;
using WhatsUrSay.Interfaces;
using WhatsUrSay.Models;

namespace WhatsUrSay.Controllers
{
    public class UserController : ApiController
    {
        static readonly IUserRepository objUserRepository = new UserRepository();
        

        // GET api/<controller>/5
        //Purpose: Invokes 'Get(string uNmae)' method 
        //Input: None
        //Output: A list of answer records from the 'User' table
        public User Get(string uName)
        {
            return objUserRepository.Find(uName);
        }

        // POST api/<controller>
        //Purpose: Invokes 'Post([FromBody]User user)' method
        //Input: None
        //Output: A list of answer records from the 'User' table
        public bool Post([FromBody]User user)
        {
            User objUser = objUserRepository.Add(user);
            if (User != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            return objUserRepository.GetUsers();
        }
    }
}