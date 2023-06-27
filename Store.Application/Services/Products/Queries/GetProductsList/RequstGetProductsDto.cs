using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetProductsList
{
    public class RequstGetProductsDto
    {
        public int Page { get; set; }
        public string? SearchKey { get; set; }
    }
}
