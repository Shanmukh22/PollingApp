/*
Component :                             An interface which declares the methods that need to be defined in 'AnswerResp.cs'
Author:                                 NikhithaKaza
Use of the component in system design:  Good coding practice
Written and revised:                    11/14/2016
Reason for component existence:         Acts as a contract that specifies the list of all methods that need to be defined in 'AnswerResp.cs'
Component usage of data structures, algorithms and control(if any):
    The component contains the declaration of below methods:
       GetAll(), Get(int id), Add(Answer Act)
    Theis method is defined in 'AnswerResp.cs'
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//It includes all the models from the project WhatsUrSay
using WhatsUrSay.Models;
using WhatsUrSay.DTO;

namespace WhatsUrSay
{
    interface IAnswer
    {
        IEnumerable<Answer> GetAll();
        Answer Get(int id);
        Answer Add(Answer Act);
        bool Update(Answer Act,int Userid);
        IQueryable<AnswerDTO> GetAnswersForCount(int activityId);
    }
}
