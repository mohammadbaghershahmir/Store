using Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Product
{
	public class Brands:BaseEntity
	{
        public string? Name { get; set; }
		public string? Slug { get; set; }
        public string? CssClass { get; set; }
        public string? Pic { get; set; }
        public ICollection<Products> Products { get; set; }
	}
}
