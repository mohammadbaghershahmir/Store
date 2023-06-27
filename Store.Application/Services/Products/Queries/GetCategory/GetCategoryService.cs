using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.ProductsSite.Queries.GetCategory;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetCategory
{
    public class GetCategoryService : IGetCategory
    {
        private readonly IDatabaseContext _context;
        public GetCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<List<CategoriesDto>>> Execute(string? Id)
        {
            var categories = _context.Category.
                 Include(p => p.ParentCategory)
                 .Include(s => s.SubCategories).
                 Where(pp => pp.ParentCategoryId == Id)
                 .ToList().Select(
                i => new CategoriesDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    HasChild = i.SubCategories.Count > 0 ? true : false,
                    Parent = i.ParentCategory != null ? new ParentCategoryDto
                    {
                        Id = i.ParentCategory.Id,
                        Name = i.ParentCategory.Name
                    } : null
                }
                ).ToList();
            return new ResultDto<List<CategoriesDto>>()
            {
                Data = categories,
                IsSuccess = true,
                Message = "لیست باموقیت برگشت داده شد"
            };

        }
    }
}
