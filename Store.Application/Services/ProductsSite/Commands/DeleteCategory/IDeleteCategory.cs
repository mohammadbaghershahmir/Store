using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Commands.DeleteCategory
{
    public interface IDeleteCategory
    {
        Task<ResultDto> Execute(string Id);
    }
}
