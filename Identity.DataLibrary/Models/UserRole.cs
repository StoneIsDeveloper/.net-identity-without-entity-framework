using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DataLibrary.Models
{
    public class UserRole
    {
        public virtual int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
