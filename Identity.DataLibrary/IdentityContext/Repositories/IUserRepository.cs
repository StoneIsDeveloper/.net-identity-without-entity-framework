using Identity.DataLibrary.Core;
using Identity.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DataLibrary.IdentityContext.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        User GetUser(int userId);
        User GetUser(string username);
    }
}
