/*
Component :                             A Web Api controller that invokes the methods defined in 'LoginRepository.cs' to serve the client requests in performing 'Login' operation on our
Author:                                 Abhinav Bhandaram
Use of the component in system design:  Serves the Login requests of the clients 
Written and revised:                    11/5/2016
Reason for component existence:         To serve Login requests of the clients
Component usage of data structures, algorithms and control(if any): 
    The component contains the below methods:
        'Login(UserInput userInfo)'
    This method is invoked by the clients upon their request for login into the application.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Repositories;
using WhatsUrSay.Models;
using WhatsUrSay.Interfaces;

namespace WhatsUrSay.Controllers
{
    public class LoginController : ApiController
    {
        //Purpose: To proces the login requests of clients into our application.
        //Input: 'userInfo' object of type 'UserInput.cs'
        //Output: a boolean variable representing the status of the login request.
        public dynamic Login(UserLoginInput userInfo)
        {
            ILoginRepository objLoginRepository = new LoginRepository();
            var result= objLoginRepository.Login(userInfo.uName, userInfo.uPassword);
            return result;
        }
        public dynamic AddUser(UserRegistrationInput userInput)
        {
            IUserRepository objUserRepository = new UserRepository();
            User user = new User();
            user.emailId = userInput.emailId;
            user.name = userInput.name;
            user.pwd = userInput.password;
            user.role = 1;
            user.status = "active";
            var result = objUserRepository.Add(user);
            return result;
        }

    }
}