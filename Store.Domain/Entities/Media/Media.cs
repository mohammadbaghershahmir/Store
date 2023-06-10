using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Media
{
    public class Media:BaseEntity
    {
        public string? Src { get; set; } 
        public string? Alt { get; set; }
        public string? Description { get; set; }
        public virtual MediaType MediaType { get; set; }
        public string MediaTypeId { get; set; }
    }
}
