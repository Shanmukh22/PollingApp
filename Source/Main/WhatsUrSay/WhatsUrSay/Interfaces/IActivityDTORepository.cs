/*
Component :                             An interface which declares the methods that need to be defined in 'ActivityDTOController.cs'
Author:                                 Sreedevi Koppula
Use of the component in system design:  Good coding practice 
Written and revised:                    11/27/2016
Reason for component existence:         Acts as a contract that specifies the list of all methods that need to be defined in 'ActivityDTOController.cs' 
Component usage of data structures, algorithms and control(if any): 
    The component contains the declaration of below methods:
        'GetAll()', 'GetPoll(int id)'
    These methods are defined in 'ActivityDTOController.cs'*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUrSay.Models;

namespace WhatsUrSay.Interfaces
{
    interface IActivityDTORepository
    {
        IEnumerable<Activity> GetAll();
        IEnumerable<Activity> GetPoll(int id);
    }
}
