using Store.Application.Services.Users.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetProductsList
{
    public class ResultGetProductsDto
    {
        public List<ProductsListDto> Products { get; set; }
        public long Rows;
    }
}
