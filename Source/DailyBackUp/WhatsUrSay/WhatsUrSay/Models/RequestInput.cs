using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUrSay.Models
{
    public class RequestInput
    {
        public bool isAuth { set; get; }
        public string emailId { set; get; }
    }
}