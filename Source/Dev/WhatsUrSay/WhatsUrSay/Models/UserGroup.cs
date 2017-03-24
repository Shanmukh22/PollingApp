using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUrSay.Models
{
    public class UserGroup
    {
       public  List<int> UserIdsDelete { get; set; }
        public List<int> UserIdsAdd { get; set; }
        public int GroupId { get; set; }
    }
}