using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Product
{
	public class Rate:BaseEntity
	{
		public virtual Products Products { get; set; }
		public string ProductsId { get; set; }
		public virtual User User { get; set; }
		public string UserId { get; set; }
        public int UserRate { get; set; }
    }
}
