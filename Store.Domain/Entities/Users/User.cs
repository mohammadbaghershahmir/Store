using Microsoft.AspNetCore.Identity;
using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Orders;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Users
{
    public class User: IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string?    FullName { get; set; }
        public int? Gender { get; set; } = 0;
        public bool IsActive { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? ProfileImage { get; set; }
        //Base Entity
        public DateTime? InsertTime { get ; set ; }
        public DateTime? UpdateTime { get ; set ; }
        public bool IsRemoved { get ; set; }
        public DateTime? RemoveTime { get ; set; }
        public ICollection<Contact> Contacts { get; set; }
		public ICollection<Product> Products { get; set; }
		public ICollection<Rate> Rates { get; set; }
		public ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
