using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Queries.GetRoles
{
    public class LoginDto
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
