using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Medias;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Product
{
	public class Products:BaseEntity
	{
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double  Price { get; set; }
        public double LastPrice { get; set; }
        public long Quantity { get; set; }
        public string? Slug { get; set; }
        public double PostageFeeBasedQuantity { get; set; }
		public double PostageFee { get; set; }
		public bool IsActive { get; set; }
        public string? Pic { get; set; }
        public string? MinPic { get; set; }
        public string? Content { get; set; }
        public virtual Category Category { get; set; }
		public string CategoryId { get; set; }
		public virtual Brands Brands { get; set; }
		public string BrandsId { get; set; }
		public virtual User User { get; set; }
		public string UserId { get; set; }
		public ICollection<ItemTag> ItemTags { get; set; }
		public ICollection<Rate> Rates { get; set; }
		public ICollection<Feature> Features { get; set; }
		public ICollection<Comments> Comments { get; set; }
		public ICollection<Media> Medias { get; set; }
	}
}
