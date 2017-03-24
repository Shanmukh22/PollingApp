using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WhatsUrSay.Models;
using WhatsUrSay.Repositories;

namespace WhatsUrSay.Controllers
{
    public class UserAnswerController : ApiController
    {

        UserAnswerRespository repo = new UserAnswerRespository();


        // GET: api/UserAnswer/
        public IHttpActionResult GetUsersParticipated([FromUri]int activityId)
        {
            int count = repo.ReturnUsersParticpated(activityId);


            return Ok(count);
        }
    }
        
}