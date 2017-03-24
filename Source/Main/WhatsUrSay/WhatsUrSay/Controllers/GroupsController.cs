/* File Name :GroupsController.cs
 * Created By: Raj 
 * This File resides in Business Layer 
 * 
 * Change History
 ************************
 ** PR   Date        Author         Description 
 ** --   --------   -------   ------------------------------------
 ** 1    11/7/2016     Raj      Created GroupsController class and incuded methods  to create ,delete,edit group details
 * This file hold business logic related to group related activities and provides services to UI layer up on request.
 * 
*/


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WhatsUrSay.Models;
using WhatsUrSay.Repositories;

namespace WhatsUrSay.Controllers
{
    public class GroupsController : ApiController
    {
        GroupsRepository groupRepository = new GroupsRepository();

        // GET: api/Groups
        /// <summary>
        /// This method returns all groups listed in database
        /// </summary>
        /// <returns></returns>
        public IQueryable<Group> GetGroups()
        {
           
            return groupRepository.GetGroups();
        }

        // GET: api/Groups/5
        /// <summary>
        /// This method get specific group details 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>group details</returns>
        [ResponseType(typeof(GroupDetails))]
        public IHttpActionResult GetGroup([FromUri]int id)
        {

            GroupDetails groupDetails = groupRepository.GetGroup(id);
            return Ok(groupDetails);
        }

        // PUT: api/Groups/5/
        /// <summary>
        /// This method updates specific group details
        /// </summary>
        /// <param name="group"></param>
        /// <returns> status code</returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroup(Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                groupRepository.UpdatGroup(group);
            }
            catch (DbUpdateConcurrencyException)
            {
               
                    throw;
               
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Groups
        /// <summary>
        /// This method  creates new group
        /// </summary>
        /// <param name="group"></param>
        /// <returns>Route of created group</returns>
       /* [ResponseType(typeof(Group))]
        public IHttpActionResult PostGroup(Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                groupRepository.CreateGroup(group);
            }
            catch (DbUpdateException)
            {
                
                    throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = group.id }, group);
        }*/

        public Group PostGroup(GroupDetails gd)
        {
            return groupRepository.CreateGroup(gd);
        }

        // DELETE: api/Groups/5
        /// <summary>
        /// This method deletes specific group
        /// </summary>
        /// <param name="id"></param>
        /// <returns> deleted group details</returns>
        [ResponseType(typeof(Group))]
        public IHttpActionResult DeleteGroup([FromUri]int id)
        {
            Group group;
            try
            {
                 group = groupRepository.DeleteGroup(id);
            }
            catch (Exception)
            {

                throw;
            }
           

            return Ok(group);
        }

        /// <summary>
        /// This method returns groups by created UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns> List of groups</returns>
        [ResponseType(typeof(List<Group>))]
        public IHttpActionResult GetGroupsByCreatedUserId([FromUri] int userId)
        {
            List<Group> groups;
            try
            {
                 groups = groupRepository.getGroupsByCreatedUserId(userId);

             
            }
            catch(Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

                return Ok(groups);

        }

      
        public IHttpActionResult PostDeleteAddUsersInGroup(UserGroup userGroup)
        {
            
            try
            {

                groupRepository.DeleteAddUsersFromGroup(userGroup);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            return StatusCode(HttpStatusCode.OK);

        }



    }
}