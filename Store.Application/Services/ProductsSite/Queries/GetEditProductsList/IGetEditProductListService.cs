using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetEditProductsList
{
    public interface IGetEditProductListService
    {
        Task<EditProductListDto> Execute(string productId);
    }
}
