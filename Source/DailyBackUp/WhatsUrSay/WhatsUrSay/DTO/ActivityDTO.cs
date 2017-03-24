using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;

namespace WhatsUrSay.DTO
{
    public class ActivityDTO
    {
        public ActivityDTO()
        {
            this.options = new HashSet<string>();
        }
        public string heading { get; set; }
        public string description { get; set; }
        public int questionId { get; set; }
        public string question { get; set; }
        public HashSet<string> options { get; set; }
    }
}