using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Users
{
    public class ContactType
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Value { get; set; }
        public string? CssClass { get; set; }
        public string? Icon { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
