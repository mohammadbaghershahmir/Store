using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.Site.SignInUser
{
    public class RequestSignInUserDto
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
