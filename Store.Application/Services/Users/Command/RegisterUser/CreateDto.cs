using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Store.Application.Services.Users.Command.RegisterUser.CreateDto
{
    public class CreateDto
    {
        public long Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [Remote(action: "IsUserExits", controller:"Common",AdditionalFields =nameof(Id))]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof (Password))]
        public string? RePassword { get; set; }
        public bool IsActive { get; set; }
        public int Gender { get; set; }
        [Required]
        [Remote(action: "IsMobileExits", controller: "Common", AdditionalFields = nameof(Id))]
        public string? Mobile { get; set; }
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailExits", controller: "Common", AdditionalFields = nameof(Id))]
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string[]? Roles { get; set; }
    }
}
