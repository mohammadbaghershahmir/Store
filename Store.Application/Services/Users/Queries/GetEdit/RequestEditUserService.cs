using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Queries.Edit
{
    public class RequestEditUserService
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public int? Gender { get; set; }
        public bool IsActive { get; set; }
        public string Mobile { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public long[] RolesId { get; set; }
    }
}
