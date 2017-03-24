using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsUrSay.Interfaces
{
    interface IUserAnswerRespository
    {
         int ReturnUsersParticpated(int activityId);
        
    }
}
