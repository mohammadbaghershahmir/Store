using Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Users
{
    public class Login:BaseEntity
    {
      
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public DateTime LastLoginDate { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }

    }
}
