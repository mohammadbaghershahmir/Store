using Microsoft.CodeAnalysis.CSharp.Syntax;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
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
            Categories categories = new Categories()

            {
                Id=Guid.NewGuid().ToString(),
                Name = requestCatgoryDto.Name,
                Description = requestCatgoryDto.Description,
                CssClass = requestCatgoryDto.CssClass,
                Slug = requestCatgoryDto.Slug,
                IsActive = requestCatgoryDto.IsActive,
                Icon = requestCatgoryDto.Icon,
                Sort = requestCatgoryDto.Sort,
                InsertTime = DateTime.Now,
                ParentCategory =  GetCategories(requestCatgoryDto.ParentId),
            };
            //Add Category
             _context.Categories.Add(categories);
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message=MessageInUser.MessageInsert
            };
        }
        private  Categories GetCategories(string? ParentId)
        {
            return  _context.Categories.Find(ParentId);
        }
    }
}
