/*
Component :                             A Web Api controller that invokes the single page application 'View'
Author:                                 Abhinav Bhandaram
Written and revised:                    11/5/2016
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatsUrSay.Controllers
{
    public class HomeController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    }
}