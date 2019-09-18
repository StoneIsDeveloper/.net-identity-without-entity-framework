using Identity.DataLibrary.IdentityContext.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DataLibrary.IdentityContext
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IdentityContext _context;
        public UnitOfWork(IdentityContext context)
        {
            _context = context;
          //  Users = new UserRepository(_context);          
        }

        public IUserRepository Users { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
