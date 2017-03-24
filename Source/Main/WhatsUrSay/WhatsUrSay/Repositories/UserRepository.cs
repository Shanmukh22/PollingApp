/*
Component :                             A class that does CRUD operations on the 'User' table of our project's database (DSE)
Author:                                 Abhinav Bhandaram
Use of the component in system design:  Used for performing CRUD operations on the 'User' table
Written and revised:                    11/5/2016
Reason for component existence:         To perform CRUD operations on the 'User' table
Component usage of data structures, algorithms and control(if any):
    Uses Entity framework class 'User.cs' to do CRUD operations on 'User' table
    The component contains the below methods:
        Add(User)
    These methods are invoked by 'UserController', a Web Api controller that serves the clients' requests
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Interfaces;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    

    public class UserRepository:IUserRepository
    {
        DSEEntities objEntities = new DSEEntities();

        //Purpose: Adds the user
        //Input: 'user' for the Add method
        //Output: 
      
        //        In case of 'null' input, the method throws 'ArgumentNullException'
        //        ELSE adds user and saves the changes and returns the output as the user 
        public User Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            objEntities.Users.Add(user);
            objEntities.SaveChanges();
            return user;
        }
        //Purpose: Finds the row whose key is uName
        //Input: Strings uName for the Find method
        //Output: Returns objEntities.Users upon finding of record in the table
        //        In case of 'null' input, the method throws 'ArgumentNullException'
        public User Find(string uName)
        {
            if (String.IsNullOrEmpty(uName))
            {
                throw new ArgumentNullException("user name");
            }            
            return objEntities.Users.Where(user => user.emailId == uName).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return objEntities.Users;
        }
    }
}