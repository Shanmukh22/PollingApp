using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Interfaces;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class LeaderShipRepository:ILeaderShipRepository
    {
        private DSEEntities objEntities = new DSEEntities();
        public dynamic RequestGroupLeaderShip(GroupLeaderShipInput request)
        {
            User_Request objUserRequest = new User_Request();
            objUserRequest.description = request.description;
            objUserRequest.user_id = request.userId;
            var userRequestSubmitted = objEntities.User_Request.Where(item => item.user_id == request.userId).ToList();
            if (userRequestSubmitted.Count() != 0)
            {
                return null;
            }
            var result=objEntities.User_Request.Add(objUserRequest);
            objEntities.SaveChanges();
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ApproveGroupLeaderShip(int id)
        {
            objEntities.User_Request.Where(item => item.id == id).FirstOrDefault().status = 1;
            var request = objEntities.User_Request.Where(item => item.id == id).FirstOrDefault();
            objEntities.Users.Where(item => item.id == request.user_id).FirstOrDefault().role=2;
            var result=objEntities.SaveChanges();
            if (result == 2)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}