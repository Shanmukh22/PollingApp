/*
Component :                             An interface which declares the methods that need to be defined in 'PollRepository.cs'
Author:                                 Sreedevi Koppula
Use of the component in system design:  Good coding practice 
Written and revised:                    11/14/2016
Reason for component existence:         Acts as a contract that specifies the list of all methods that need to be defined in 'PollRepository.cs' 
Component usage of data structures, algorithms and control(if any): 
    The component contains the declaration of below methods:
        'GetAll()', 'Get(int id)', 'Add(Activity activity)'
    These methods are defined in 'PollRepository.cs'
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;

namespace WhatsUrSay.Interfaces
{
    interface IPollRepository
    {

        IEnumerable<Activity> GetAll();
        IEnumerable<Activity> GetPoll(int id);
        //ActivityGroupDetails Get(int id);
        //Activity Add(Activity activity);
        Activity Add(ActivityGroupDetails activity);
    }
}