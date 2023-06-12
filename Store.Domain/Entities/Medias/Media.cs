using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Product;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Medias
{
    public class Media:BaseEntity
    {
        public string? Src { get; set; } 
        public string? Alt { get; set; }
        public string? Description { get; set; }
        public virtual MediaType MediaType { get; set; }
        public string MediaTypeId { get; set; }
		public virtual Products Products { get; set; }
		public string ProductsId { get; set; }
	}
}
