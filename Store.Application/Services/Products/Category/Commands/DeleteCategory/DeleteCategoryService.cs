using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Products.Category.Commands.GetParentCategory;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Category.Commands.DeleteCategory
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
            // var category=_databaseContext.Categories.Where(r=>r.Id == Id).ToList();
            // var list = category.FirstOrDefault();
            // if(list.ParentCategoryId==null)
            // {

            //     //Remove Logical


            // }
            //else
            // {
            //     list.RemoveTime = DateTime.Now;
            //     list.IsRemoved = true;
            //     await _databaseContext.SaveChangesAsync();
            // }

          
            var listCategory = await _context.Categories.Where(i=>i.Id==Id).Select
                (
                e => new DeleteListCategoryDto()
                {
                    IsRemove=e.IsRemoved,
                    RemoveTime=e.RemoveTime,
                    ParentId=e.ParentCategoryId,
                    Id=e.Id
                }
                ).ToListAsync();

            AllCategory.AddRange(listCategory);

            foreach (var item in listCategory.Where(e => e.ParentId == null))
            {
                int level = 1;
                item.IsRemove = true;
                item.RemoveTime = DateTime.Now;
                _context.SaveChanges();
                var child = listCategory.ToList();
                listGenerator(child, level);
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
                    itemChild.RemoveTime = DateTime.Now;
                    itemChild.IsRemove = true;
                    _context.SaveChanges();
                    listGenerator(childN, level);
                }
                else
                {
                    itemChild.RemoveTime = DateTime.Now;
                    itemChild.IsRemove = true;
                    _context.SaveChanges();
                }
            }
            return;
        }
    }
}
