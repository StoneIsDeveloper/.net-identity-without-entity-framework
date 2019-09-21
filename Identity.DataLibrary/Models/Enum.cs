using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DataLibrary.Models
{
    public  class Enum
    {
    }
    public enum EnumUserStatus
    {
        Pending = 0,
        Active = 1,
        LockedOut = 2,
        Closed = 3,
        Banned = 4
    }
}
