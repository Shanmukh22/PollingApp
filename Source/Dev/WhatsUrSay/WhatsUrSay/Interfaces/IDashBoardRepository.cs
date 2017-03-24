using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Repositories;
using WhatsUrSay.Models;
using WhatsUrSay.Interfaces;

namespace WhatsUrSay.Interfaces
{
    public interface IDashBoardRepository
    {
        dynamic Get(DashboardInput userInfo);
    }
}