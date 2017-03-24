/*
Component :                             A class that does CRUD operations on the 'User' table of our project's database (DSE)
Author:                                 Abhinav Bhandaram
Use of the component in system design:  Used for performing CRUD operations on the 'User' table
Written and revised:                    11/5/2016
Reason for component existence:         To perform CRUD operations on the 'User' table
Component usage of data structures, algorithms and control(if any):
    Uses Entity framework class 'User.cs' to do CRUD operations on 'User' table
    The component contains the below methods:
        'Login(uName, uPassword)'
    These methods are invoked by 'UserController', a Web Api controller that serves the clients' requests
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Includes all the Models from the WhatsUrSay
using WhatsUrSay.Models;
using WhatsUrSay.Interfaces;

namespace WhatsUrSay.Repositories
{
    public class LoginRepository:ILoginRepository
    {
        //Purpose: Finds the row whose key is uName, uPassword
        //Input: Strings uName, uPassword for the Login method
        //Output: Returns 'true' upon successfully finding of record in the table
        //        In case of 'null' input, the method throws 'ArgumentNullException'
        public User Login(string uName, string uPassword)
        {
            UserRepository objUserRepository = new UserRepository();
            User user = objUserRepository.Find(uName);
            if (user == null)
            {
                return null;
            }
            else
            {
                if(String.Equals(user.pwd, uPassword))
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }            
        }
    }
}