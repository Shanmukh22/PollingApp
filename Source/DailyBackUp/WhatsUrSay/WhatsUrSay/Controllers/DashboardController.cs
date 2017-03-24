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
    public class DashboardController : ApiController
    {
        //Purpose: To proces the Dashboard requests of clients into our application.
        //Input: 'userId' and userRole object of type 'DashboardInput.cs'
        //Output: List of activities associated with the user.
        [System.Web.Http.HttpPost]
        public dynamic GetDashboard(DashboardInput userInfo)
        {
            IDashBoardRepository objDBRepository = new DashboardRepository();
            var result = objDBRepository.Get(userInfo);
            return result;
        }
    }
}
