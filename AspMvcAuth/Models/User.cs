using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMvcAuth.Models
{
    public class User
    {
        public int Id { get; set; }

        public string userName { get; set; }

        public string password { get; set; }

        public bool status { get; set; }
    }
}