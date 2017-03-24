using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUrSay.Models
{
    public class UserAnswersList
    {
        public List<Answer> Answers { get; set; }

        public int UserId { get; set; }
    }
}