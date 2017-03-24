/*
Component :                             An interface which declares the methods that need to be defined in 'SurveyResp.cs'
Author:                                 NikhithaKaza
Use of the component in system design:  Good coding practice
Written and revised:                    11/14/2016
Reason for component existence:         Acts as a contract that specifies the list of all methods that need to be defined in 'SurveyResp.cs'
Component usage of data structures, algorithms and control(if any):
    The component contains the declaration of below methods:
       GetAll(), Activity Get(int id), Activity Add(Activity Act);
    Theis method is defined in 'SurveyResp.cs'
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//It includes all the models from the WhatsUrSay
using WhatsUrSay.Models;

namespace WhatsUrSay
{
    interface ISurvey
    {
        
            IEnumerable<Activity> GetAll();
            Activity Get(int id);
            Activity Add(Activity Act);
           
        }
    }
