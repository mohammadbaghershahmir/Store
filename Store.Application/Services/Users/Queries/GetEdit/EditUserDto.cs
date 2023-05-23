using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Queries.GetUsers;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
namespace Store.Application.Services.Users.Queries.Edit
{
    public class EditUserDto
    {
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
		[Required]
		public string? LastName { get; set; }
		[Required]
		[Remote(action: "IsEmailExits", controller: "Common", AdditionalFields = nameof(Id))]
        public string? Email { get; set; }
		public int? Gender { get; set; }
		public bool IsActive { get; set; }
		[Required]
		[Remote(action: "IsMobileExits", controller: "Common", AdditionalFields = "Id")]
        public string? Mobile { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public long[] IdesInRole { get; set; }

        public List<LoginDto> Login { get; set; }


    }
}
