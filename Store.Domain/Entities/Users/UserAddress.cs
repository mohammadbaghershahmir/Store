using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Users
{
    public class UserAddress:BaseEntity
    {
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public virtual Province City { get; set; }
        public string CityId { get; set; }
        public int PostalCode { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
