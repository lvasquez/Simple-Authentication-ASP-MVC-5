using AspMvcAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMvcAuth.Repositories
{
    public interface IAccount
    {
        IEnumerable<User> getUsers();
    }
}
