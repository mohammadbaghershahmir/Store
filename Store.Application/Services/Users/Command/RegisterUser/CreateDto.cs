using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EndPointStore.Areas.Admin.Controllers
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
        public string? Password { get; set; }
        [Required]
        public string? RePassword { get; set; }
        public bool IsActive { get; set; }
        public int Gender { get; set; }
        [Required]
        [Remote(action: "IsMobileExits", controller: "Common", AdditionalFields = nameof(Id))]
        public string Mobile { get; set; }
        [Required]
        [Remote(action: "IsEmailExits", controller: "Common", AdditionalFields = nameof(Id))]
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public long[] RolesId { get; set; }
    }
}
