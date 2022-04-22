using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.DataAccessor.Enums
{
    public enum AssetStateEnum
    {
        Available = 1,
        NotAvailable = 2,
        Assigned = 3,
        WaitingForRecycling = 4,
        Recycled = 5,
    }
}
