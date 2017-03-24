using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUrSay.Models
{
    public class UserRegistrationInput
    {
        public string emailId { get; set; }
        public string password { get; set; }
        public string name { get; set; }

    }
}