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
    public class PollAnswerDetailsController : ApiController
    {
        DSEEntities db = new DSEEntities();
        PollAnswerDetailsRepository repo = new PollAnswerDetailsRepository();

        public Answer PostPollAnswer(PollAnswerDetails answer)
        {
            try
            {
                return repo.Add(answer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
