using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrennToDo.Models.Identity
{
    public class UserWithToken
    {
        public class UserAndToken
        {
            public string UserId { get; set; }
            public string Token { get; set; }
        }
    }
}
