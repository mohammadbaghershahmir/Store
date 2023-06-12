using Microsoft.CodeAnalysis.CSharp.Syntax;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Category.Queries.AddNewCategory
{
    public class AddCategoryService : IAddCategory
    {
        private readonly IDatabaseContext _context;
        public AddCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(RequestCatgoryDto requestCatgoryDto)
        {
            //Check Edit Or Create
            if (requestCatgoryDto.Id != null)
            {

                var EditList = await _context.Category.FindAsync(requestCatgoryDto.Id);
                EditList.Name = requestCatgoryDto.Name;
                EditList.Slug = requestCatgoryDto.Slug;
                EditList.IsActive = requestCatgoryDto.IsActive;
                EditList.ParentCategoryId = requestCatgoryDto.ParentId;
                EditList.Description = requestCatgoryDto.Description;
                await _context.SaveChangesAsync();
            }
            else
            {
                Domain.Entities.Product.Category categories = new Domain.Entities.Product.Category()

                {
                    Id = Guid.NewGuid().ToString(),
                    Name = requestCatgoryDto.Name,
                    Description = requestCatgoryDto.Description,
                    CssClass = requestCatgoryDto.CssClass,
                    Slug = requestCatgoryDto.Slug,
                    IsActive = requestCatgoryDto.IsActive,
                    Icon = requestCatgoryDto.Icon,
                    Sort = requestCatgoryDto.Sort,
                    InsertTime = DateTime.Now,
                    ParentCategory = GetCategories(requestCatgoryDto.ParentId),
                };
                //Add Category
                _context.Category.Add(categories);
                _context.SaveChanges();
            }
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ثبت موفق"
            };
        }
        private Domain.Entities.Product.Category GetCategories(string? ParentId)
        {
            return  _context.Category.Find(ParentId);
        }
    }
}
