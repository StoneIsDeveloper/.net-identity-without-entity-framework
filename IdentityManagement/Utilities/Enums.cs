﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManagement.Utilities
{
    public enum EnumUserStatus
    {
        Pending = 0,
        Active = 1,
        LockedOut = 2,
        Closed = 3,
        Banned = 4
    }
}
