/* File Name :GroupsRepository.cs
 * Created By: Raj
 * This File resides in Business Layer 
 * 
 * Change History
 ************************
 ** PR   Date        Author         Description 
 ** --   --------   -------   ------------------------------------
 ** 1    11/6/2016     Raj      Created GroupsRepository class and incuded methods  to modify group data
 *  2    11/15/2016     Raj     implemeted IGroupsRepository methods
 * This file  performs CRUD operations on Group Table
 * 
*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WhatsUrSay.Interfaces;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class GroupsRepository:IGroupsRepository
    {
        private DSEEntities db = new DSEEntities();

        /// <summary>
        /// This method returns all groups
        /// </summary>
        /// <returns></returns>
        public IQueryable<Group> GetGroups()
        {
            return db.Groups;
        }

        /// <summary>
        /// This method returns specific group details
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public GroupDetails GetGroup(int groupId)
        {
            Group group = db.Groups.Find(groupId);
            if (group == null)
            {
                throw new ArgumentNullException("Group not found");
            }
            GroupDetails groupDetails = null;
            /*
            try
            {
            groupDetails = new GroupDetails();
            groupDetails.group = group;
            groupDetails.UserList = new List<UserDetails>();
            string[] users = group.user_ids.Split(',');

            foreach (var userId in users)
            {
                User user = db.Users.Find(Int32.Parse(userId));

                groupDetails.UserList.Add(new UserDetails() { Id = user.id, Name = user.name });
            }
            }
            catch (Exception)
            {

                throw;
            }*/
            return groupDetails;
        }

        /// <summary>
        /// This method updates group details
        /// </summary>
        /// <param name="group"></param>
        /// <returns>true or false   </returns>
        public bool UpdatGroup(Group group)
        {
            db.Entry(group).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                return false;

            }

            return true;
        }

        /// <summary>
        /// This method returns created group details
        /// </summary>
        /// <param name="group"></param>
        /// <returns> created group  object</returns>
      /*  public Group CreateGroup(Group group)
        {
            

            db.Groups.Add(group);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupExists(group.id))
                {
                    throw new Exception("Conflit");
                }
                else
                {
                    throw;
                }
            }

            return group;
        }*/


        public Group CreateGroup(GroupDetails gd)
        {
            LinkedList<User_Group> grps = new LinkedList<User_Group>();
            foreach (UserDetails ud in gd.UserList)
            {
                User_Group userGrp = new User_Group();
                userGrp.user_id = (db.Users.Where(user => user.emailId == ud.emailId).FirstOrDefault()).id;
                grps.AddLast(userGrp);
            }

            Group group = new Group();
            group.name = gd.group.name;
            group.createdby = gd.group.createdby;
            group.User_Group = grps;

            db.Groups.Add(group);
            db.SaveChanges();

            return group;
        }
        /// <summary>
        /// Deletes group
        /// </summary>
        /// <param name="id"></param>
        /// <returns> deteleted group object</returns>
        public Group DeleteGroup(int id)
        {
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                throw new ArgumentNullException("Group not found to delete");
            }

            db.Groups.Remove(group);
            db.SaveChanges();

            return group;

        }


        public List<Group> getGroupsByCreatedUserId(int UserId)
        {
            db.Configuration.LazyLoadingEnabled = false;

            List<Group> groups;
                try
            {
                groups = db.Groups.Where(e => e.createdby == UserId).ToList<Group>();
                foreach(var group in groups)
                {
                                 
                    db.Entry(group).Collection(e => e.User_Group).Load();
                    foreach (var usergroup in group.User_Group)
                    {
                         db.Entry(usergroup).Reference(e => e.User).Load();

                    }

          
                    
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return groups;
        }


        public void DeleteAddUsersFromGroup(UserGroup group)
        {
           

            foreach (int id in group.UserIdsDelete)
            {
                User_Group userGroup = db.User_Group.First(e => e.user_id == id&&e.group_id==group.GroupId);

                db.User_Group.Remove(userGroup);
            }

            foreach (int id in group.UserIdsAdd)
            {
                User_Group userGroup = new User_Group() { user_id = id, group_id = group.GroupId };
                db.User_Group.Add(userGroup);
            }

            db.SaveChanges();
        }
        /// <summary>
        /// Finds if group exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns> true or false</returns>
        private bool GroupExists(int id)
        {
            return db.Groups.Count(e => e.id == id) > 0;
        }


        
    }
}