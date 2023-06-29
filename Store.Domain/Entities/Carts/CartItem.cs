using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Products;

namespace Store.Domain.Entities.Carts
{
    public class CartItem : BaseEntity
    {
        public virtual Product Product { get; set; }
        public string ProductId { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public virtual Cart Cart { get; set; }
        public string CartId { get; set; }


    }
}
