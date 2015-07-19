using AspMvcAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMvcAuth.Data
{
    public class DomainData
    {
        public IEnumerable<User> getUsers()
        {
            IList<User> users = new List<User>();
            users.Add(new User() { Id = 1, userName = "admin", password = "12345", status = true });
            users.Add(new User() { Id = 2, userName = "invite", password = "12345", status = false });

            return users.ToList();
        }
    }
}