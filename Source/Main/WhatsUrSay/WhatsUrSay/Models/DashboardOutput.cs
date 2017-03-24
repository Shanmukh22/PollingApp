using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUrSay.Models
{
    public class DashboardOutput
    {
        public List<Activity> publicActivities = new List<Activity>();
        public List<Activity> privateActivities = new List<Activity>();
        public List<Group> groups = new List<Group>();
        public List<User_Request> requests = new List<User_Request>();
        public List<Activity> createdActitvities = new List<Activity>();
        public Dictionary<int, List<int>> userAnswer = new Dictionary<int, List<int>>();
        public List<Group> user_groups = new List<Group>();
    }
}