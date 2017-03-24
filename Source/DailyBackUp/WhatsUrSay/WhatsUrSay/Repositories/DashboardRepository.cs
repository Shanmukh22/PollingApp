using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Repositories;
using WhatsUrSay.Models;
using WhatsUrSay.Interfaces;

namespace WhatsUrSay.Repositories
{
    public class DashboardRepository : IDashBoardRepository
    {
        public dynamic Get(DashboardInput userInfo)
        {
            DSEEntities objEntities = new DSEEntities();
            List<Activity> privateActivities = new List<Activity>();
            List<Group> userCreatedGroups = new List<Group>();
            List<User_Request> userRequests = new List<User_Request>();
            List<Activity_Group> groupActivities = new List<Activity_Group>();
            List<Group> user_groups = new List<Group>();
            var publicActivites = objEntities.Activities.Where(act => act.type == 1).ToList();
            var createdActivities = objEntities.Activities.Where(act => act.createdby == userInfo.userId).ToList();
            var userGroups = objEntities.User_Group.Where(group => group.user_id == userInfo.userId).ToList();            
            var user_answer = objEntities.User_Answer.Where(usanswr => usanswr.user_id == userInfo.userId).ToList();            
            var user_activity = this.getDistinct(user_answer);

            if (userGroups != null)
            {
                foreach (var userGroup in userGroups)
                {
                    var Group = objEntities.Groups.Where(group => group.id == userGroup.group_id).FirstOrDefault();
                    user_groups.Add(Group);
                }
            }
            if (userGroups != null)
            {
                foreach (var grp in userGroups)
                {
                    groupActivities = objEntities.Activity_Group.Where(actgrp => actgrp.group_id == grp.group_id).ToList();
                }
            }
            if (groupActivities != null)
            {
                foreach (var grpact in groupActivities)
                {
                    var activity = objEntities.Activities.Where(act => act.id == grpact.activity_id).FirstOrDefault();
                    privateActivities.Add(activity);
                }
            }
            
            if (userInfo.role != 1)
            {
                userCreatedGroups = objEntities.Groups.Where(grp => grp.createdby == userInfo.userId).ToList();
            }
            if (userInfo.role == 3)
            {
                userRequests = objEntities.User_Request.ToList();
            }
            DashboardOutput objDBOutput = new DashboardOutput();
            objDBOutput.groups = userCreatedGroups;
            objDBOutput.privateActivities = privateActivities;
            objDBOutput.publicActivities = publicActivites;
            objDBOutput.requests = userRequests;
            objDBOutput.createdActitvities = createdActivities;
            objDBOutput.userAnswer = user_activity;
            objDBOutput.user_groups = user_groups;
            return objDBOutput;
        }
        private Dictionary<int, List<int>> getDistinct(List<User_Answer> inputList)
        {
            Dictionary<int, List<int>> outputList = new Dictionary<int, List<int>>();
            foreach (var usranwr in inputList)
            {
                if (outputList.ContainsKey(usranwr.user_id))
                {
                    var data = outputList[usranwr.user_id];
                    if (data.Contains(usranwr.activity_id))
                    {
                        continue;
                    }else
                    {
                        outputList[usranwr.user_id].Add(usranwr.activity_id);
                    }
                }
                else
                {
                    var dataList = new List<int>();
                    dataList.Add(usranwr.activity_id);
                    outputList.Add(usranwr.user_id, dataList);
                }
            }
            return outputList;
        }
    }
}