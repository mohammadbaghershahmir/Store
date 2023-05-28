using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.RegisterUser
{
    public class RequestRegisterUserDto
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? Gender { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? RePassword { get; set; }
        public bool IsActive { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string[]? Roles { get; set; }
    }
}
