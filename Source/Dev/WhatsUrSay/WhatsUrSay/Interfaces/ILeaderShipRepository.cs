using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUrSay.Models;

namespace WhatsUrSay.Interfaces
{
    interface ILeaderShipRepository
    {
        dynamic RequestGroupLeaderShip(GroupLeaderShipInput request);
        bool ApproveGroupLeaderShip(int userId);
    }
}
