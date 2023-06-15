using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.ProductsSite.Category.Commands.GetParentCategory;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Category.Commands.DeleteCategory
{
    public class DeleteCategoryService : IDeleteCategory
    {
        private readonly IDatabaseContext _context;
        public DeleteCategoryService(IDatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
        public static List<DeleteListCategoryDto> Category = new List<DeleteListCategoryDto>();
        public static List<DeleteListCategoryDto> AllCategory = new List<DeleteListCategoryDto>();
        public async Task<ResultDto> Execute(string Id)
        {
            Category.Clear();
            AllCategory.Clear();
            var listCategory = await _context.Category.Select
                (
                e => new DeleteListCategoryDto()
                {
                    Id = e.Id,
                    ParentId = e.ParentCategoryId,
                }
                ).ToListAsync();

            AllCategory.AddRange(listCategory);

            foreach (var item in listCategory.Where(e=> e.Id==Id))
            {
                int level = 1;
                Category.Add(new DeleteListCategoryDto()
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                });
                var child = listCategory.Where(y => y.ParentId == item.Id).ToList();
                listGenerator(child, level);
            }
            foreach (var remove in Category)
            {
                var ItemRemove = _context.Category.Where(r => r.Id == remove.Id).FirstOrDefault();
                if (ItemRemove != null)
                {
                    ItemRemove.IsRemoved = true;
                    ItemRemove.RemoveTime = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
                
            }
            //Show Result
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageDelete
            };
        }
        public void listGenerator(List<DeleteListCategoryDto> selectList, int level)
        {
            level++;
            foreach (var itemChild in selectList)
            {
                var childN = AllCategory.Where(p => p.ParentId == itemChild.Id).ToList();
                if (childN.Any())
                {
                    Category.Add(new DeleteListCategoryDto()

                    {
                        Id = itemChild.Id,
                        ParentId = itemChild.ParentId,
                    });
                    listGenerator(childN, level);
                }
                else
                {
                    Category.Add(new DeleteListCategoryDto()
                    {
                        Id = itemChild.Id,
                        ParentId = itemChild.ParentId,
                    });
                }
            }
            return;
        }
    }
}
