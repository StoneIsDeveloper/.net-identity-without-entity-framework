using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IdentityLibrary
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        { }
        public ApplicationRole(string roleName) : base(roleName)
        { }
        public string Description { get; set; }
    }
}
