using Store.Common.Dto;
using Store.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Category.Commands.GetParentCategory
{
    public interface IGetParentCategory
    {
        Task<List<ParentCategoryDto>> Execute();
    }
}
