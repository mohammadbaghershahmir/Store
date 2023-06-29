using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Products
{
	public class ItemTag:BaseEntity
	{
		public virtual Tag Tag { get; set; }
		public string TagId { get; set; }
		public virtual Product Product { get; set; }
		public string ProductId { get; set; }

    }
}
