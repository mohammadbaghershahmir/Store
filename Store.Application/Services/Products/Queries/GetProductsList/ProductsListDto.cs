using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetProductsList
{
    public class ProductsListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Pic { get; set; }
        public string? Category { get; set; }
        public double Price { get; set; }
        public long Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime?  InsertTime { get; set; }

    }
}
