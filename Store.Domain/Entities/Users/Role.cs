using Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Users
{
    public class Role:BaseEntity
    {
    
        public string? NameRole { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }  
    }
}
