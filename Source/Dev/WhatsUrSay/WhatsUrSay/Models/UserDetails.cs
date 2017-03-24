/* File Name :GroupDetails.cs
 * Created By: Raj
 * This file resides in business layer
 * Change History
 ************************
 ** PR   Date        Author         Description 
 ** --   --------   -------   ------------------------------------
 ** 1    11/8/2016     Raj      Created UserDetails class and incuded properties to hold user data
 * This file contains properties that hold user  data
 * 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUrSay.Models
{
    public class UserDetails
    {
        /// <summary>
        /// Properties to hold user data
        /// </summary>
       public string emailId { get; set; }
       public int Id { get; set; }
 
    }
}