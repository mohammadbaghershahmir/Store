using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetProductsList
{
    public interface IGetProductsListService
    {
        Task<ResultGetProductsDto> Execute(RequstGetProductsDto requstGetProducts);
    }
}
