using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUrSay.Models
{
    public class SurveyDetails
    {
         public String heading { get; set; }
        public String description { get; set; }
        public int type { get; set; }
        public int category { get; set; }
        public int createdby { get; set; }

        public Dictionary<Question, HashSet<Answer>> Questions { get; set; } 
        public HashSet<Group> Groups { get; set; }
    }
}