using Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Product
{
	public class Tag:BaseEntity
	{
        public string Name { get; set; }
		public ICollection<ItemTag> ItemTags { get; set; }

	}
}
