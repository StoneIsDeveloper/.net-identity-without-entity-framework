using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DataLibrary.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }

        public Role()
        {
            UserRole = new List<UserRole>();
        }
    }
}
