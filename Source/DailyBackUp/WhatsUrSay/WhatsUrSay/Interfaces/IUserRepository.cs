/*
Component :                             An interface which declares the methods that need to be defined in 'IUserRepository.cs'
Author:                                 Abhinav Bhandaram
Use of the component in system design:  Good coding practice
Written and revised:                    11/14/2016
Reason for component existence:         Acts as a contract that specifies the list of all methods that need to be defined in 'IUserRepository.cs'
Component usage of data structures, algorithms and control(if any):
    The component contains the declaration of below methods:
      Add(User user), User Find(string uName)
    Theis method is defined in 'IUserRepository.cs'
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUrSay.Models;

namespace WhatsUrSay.Interfaces
{
    interface IUserRepository
    {
        //Declarations of the methods Add and Method Find
        User Add(User user);
        User Find(string uName);
        IEnumerable<User> GetUsers();
    }
}
