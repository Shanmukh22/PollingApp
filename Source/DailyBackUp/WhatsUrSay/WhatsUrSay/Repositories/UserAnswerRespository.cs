using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Interfaces;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class UserAnswerRespository : IUserAnswerRespository
    {
        private DSEEntities db = new DSEEntities();

       public  int ReturnUsersParticpated(int activityId)
        {
            int count = db.User_Answer.Where(e => e.activity_id == activityId).Select(e => e.user_id).Distinct().Count();

            return count;
        }

        
    }
}