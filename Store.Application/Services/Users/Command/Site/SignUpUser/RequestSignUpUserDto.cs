using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Users.Command.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

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
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string? RePassword { get; set; }
        public string RolesId { get; set; }
    }
}
