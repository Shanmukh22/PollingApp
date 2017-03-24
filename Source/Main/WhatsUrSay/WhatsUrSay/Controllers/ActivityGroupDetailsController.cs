using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Models;
using WhatsUrSay.Repositories;

namespace WhatsUrSay.Controllers
{
    public class ActivityGroupDetailsController : ApiController
    {
        PollRepository repo = new PollRepository();

        public Activity PostPoll(ActivityGroupDetails activity)
        {
            try
            {
                return repo.Add(activity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
