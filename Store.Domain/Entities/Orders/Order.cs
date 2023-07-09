using Store.Common.Constant.OrderState;
using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Finances;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public virtual RequestPay RequestPay { get; set; }
        public string RequestPayId { get; set; }
        public OrderState OrderState { get; set; }
        public string  Name { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public int PostalCode { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? TrackingPost { get; set; }
        public bool Seen { get; set; } = false;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
    public class OrderDetail : BaseEntity
    {
        public virtual Order Order { get; set; }
        public string OrderId { get; set; }
        public virtual Product Product { get; set; }
        public string ProductId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

    }
}
