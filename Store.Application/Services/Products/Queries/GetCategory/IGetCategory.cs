using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetCategory
{
    public interface IGetCategory
    {
        Task<ResultDto<List<CategoriesDto>>> Execute(string? Id);
    }
}
