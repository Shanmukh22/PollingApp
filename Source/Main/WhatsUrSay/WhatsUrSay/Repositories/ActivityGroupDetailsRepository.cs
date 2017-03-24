using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.DTO;
using WhatsUrSay.Models;
using System.Collections;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace WhatsUrSay.Repositories
{
    public class ActivityGroupDetailsRepository
    {
        private DSEEntities db = new DSEEntities();

        //Purpose: Adds an object 'activity' in the 'Activity' table
        //Input: 'activity' object of type 'Activity.cs'
        //Output: Returns the object 'activity' upon its successful addition in the table
        //        If any exception occurs, the exception message is printed and the exception is thrown
        public Activity Add(ActivityGroupDetails act)
        {
            if (act == null)
                throw new ArgumentNullException("activity");

            try
            {
                LinkedList<Activity_Group> grps = new LinkedList<Activity_Group>();
                //Activity_Group ag = new Activity_Group();
                foreach (Group g in act.Groups)
                {
                    Activity_Group ag = new Activity_Group();
                    ag.group_id = (db.Groups.Where(group => group.name == g.name).FirstOrDefault()).id;
                    grps.AddLast(ag);
                    //grps.Add(ag);
                }

                Activity activity = new Activity();
                activity.heading = act.heading;
                activity.description = act.description;
                activity.type = act.type;
                activity.category = act.category;
                activity.createdby = act.createdby;
                activity.Questions = act.Questions;
                activity.Answers = act.Answers;
                activity.Activity_Group = grps;
                db.Activities.Add(activity);
                db.SaveChanges();


                return activity;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
                throw e;
            }
        }

    }
}