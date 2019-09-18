using Identity.DataLibrary.IdentityContext.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DataLibrary.IdentityContext
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
        
    }
}
