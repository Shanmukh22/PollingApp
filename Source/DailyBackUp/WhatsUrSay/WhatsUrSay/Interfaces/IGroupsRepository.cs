/* File Name :IGroupsRepository.cs
 * Created By: Raj
 * This file resides in business layer
 * Change History
 ************************
 ** PR   Date        Author         Description 
 ** --   --------   -------   ------------------------------------
 ** 1    11/15/2016     Raj      Created GroupDetails class and incuded properties
 * This interface forces GroupsRepository to implement method specified in this file.
 * 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;

namespace WhatsUrSay.Interfaces
{
    public interface IGroupsRepository
    {   

        /// <summary>
        /// Method definitions to force GroupRepository to implements  these methods
        /// </summary>
        /// <returns></returns>
        IQueryable<Group> GetGroups();
        GroupDetails GetGroup(int groupId);
        bool UpdatGroup(Group group);
        //Group CreateGroup(Group group);
        Group CreateGroup(GroupDetails gd);
        Group DeleteGroup(int id);
    }
}