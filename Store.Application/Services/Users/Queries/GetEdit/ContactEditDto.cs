using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Queries.Edit
{
    public class ContactEditDto
    {
        public long UserId { get; set; }
        public long CId { get; set; }
        public string Value { get; set; }
    }
}
