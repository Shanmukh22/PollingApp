using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Models;
using WhatsUrSay.Interfaces;
using WhatsUrSay.Repositories;

namespace WhatsUrSay.Controllers
{
    public class LeaderShipController : ApiController
    {
        private ILeaderShipRepository objRepository=new LeaderShipRepository();
        public dynamic RequestGroupLeaderShip(GroupLeaderShipInput request)
        {
            var result = objRepository.RequestGroupLeaderShip(request);
            return result;
        }
        public bool ApproveGroupLeaderShip(int id)
        {
            var result=objRepository.ApproveGroupLeaderShip(id);
            return result;
        }
    }
}
