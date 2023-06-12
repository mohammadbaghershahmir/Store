using Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Product
{
	public class Feature:BaseEntity
	{
		public virtual Products Products { get; set; }
		public string ProductsId { get; set; }
		public string DisplayName { get; set; }
        public string? Value { get; set; }
    }
}
