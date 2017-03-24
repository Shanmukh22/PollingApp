using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUrSay.Models
{
    public class PollAnswerDetails
    {
        public int userId { get; set; }
        public int activityId { get; set; }
        public int questionId { get; set; }
        public string answerDesc { get; set; }
    }
}