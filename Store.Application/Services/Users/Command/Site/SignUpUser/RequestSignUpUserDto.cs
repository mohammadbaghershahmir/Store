using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Users.Command.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.Site.SignUpUser
{
    public class RequestSignUpUserDto
    {
        [Required]
        public string? FullName { get; set; }
        [Required]
        [Remote(action: "IsMobileExits", controller: "Common")]
        public string? Mobile { get; set; }
        [Required]
        [Remote(action: "IsEmailExits", controller: "Common")]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? RePassword { get; set; }
        public long RolesId { get; set; }
    }
}
