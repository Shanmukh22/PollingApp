using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class PollAnswerDetailsRepository
    {
        private DSEEntities db = new DSEEntities();

        
        public Answer Add(PollAnswerDetails answer)
        {
            if (answer == null)
                throw new ArgumentNullException("answer");

            try
            {
                User_Answer user_ans = new User_Answer();
                //ans.description = answer.answerDesc;
                user_ans.answer_id = (db.Answers.Where(a => (a.description == answer.answerDesc && a.question_id==answer.questionId)).FirstOrDefault()).id;
                user_ans.user_id = answer.userId;
                user_ans.activity_id = answer.activityId;
                user_ans.question_id = answer.questionId;

                db.User_Answer.Add(user_ans);
                db.SaveChanges();

                Answer ans = db.Answers.Where(a => a.id == user_ans.answer_id).FirstOrDefault();
                if(ans.count == null)
                {
                    ans.count = 1;
                }
                else
                {
                    ans.count = ans.count + 1;
                }  
                db.SaveChanges();

                //int count = (int)db.Answers.Where(a => a.id == user_ans.answer_id).FirstOrDefault().count;
                //count = count + 1;
                //db.Answers.Select(string.Format());

                return ans;
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