using Microsoft.AspNetCore.Identity;
using Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Users
{
    public class Role:IdentityRole
    {
      

        public string? Description { get; set; }
        public string? PersianTitle { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? ProfileImage { get; set; }
        //Base Entity
        public DateTime? InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? RemoveTime { get; set; }
      

    }
}
