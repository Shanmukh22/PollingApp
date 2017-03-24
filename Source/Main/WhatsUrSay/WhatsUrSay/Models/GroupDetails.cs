/* File Name :GroupDetails.cs
 * Created By: Raj
 * This file resides in business layer
 * Change History
 ************************
 ** PR   Date        Author         Description 
 ** --   --------   -------   ------------------------------------
 ** 1    11/8/2016     Raj      Created GroupDetails class and incuded properties
 * This file contains properties that hold group data
 * 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUrSay.Models
{
    public class GroupDetails
    {
        /// <summary>
        /// Properties to hold group and it users data
        /// </summary>
        public Group group { get; set; }
        public List<UserDetails> UserList {get; set;}
    }
}