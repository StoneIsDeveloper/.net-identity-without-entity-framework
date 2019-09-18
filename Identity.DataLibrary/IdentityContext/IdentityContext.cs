using Identity.ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DataLibrary.IdentityContext
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new UserMapping());
            //modelBuilder.Configurations.Add(new RoleMapping());
            //modelBuilder.Configurations.Add(new UserRoleMapping());
        }

    }
}
