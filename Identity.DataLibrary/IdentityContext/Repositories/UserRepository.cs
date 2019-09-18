using Identity.DataLibrary.Core;
using Identity.ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DataLibrary.IdentityContext.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly IdentityContext _context;

        public UserRepository(DbContext context) : base(context)
        {
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
