using Microsoft.Build.Framework;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Commands.AddNewBrand
{
    public interface IAddNewBrandService
    {
        Task<ResultDto> Execute(BrandsDto brandsDto);
    }
    public class AddNewBrandService : IAddNewBrandService
    {
        private readonly IDatabaseContext _context;
        public AddNewBrandService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(BrandsDto brandsDto)
        {
            if (brandsDto.Id != null)
            {
                var editBrands = _context.Brands.Find(brandsDto.Id);
                editBrands.Name = brandsDto.Name;
                editBrands.Slug = brandsDto.Slug;
                editBrands.Pic = brandsDto.Image;
                editBrands.UpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "ویرایش موفق"
                };
            }
            var checkSlug = _context.Brands.Where(b => b.Slug == brandsDto.Slug).FirstOrDefault();
            if(checkSlug!=null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.ExistSlug
                };
            }
            Brand brand=new Brand()
            {
                Id=Guid.NewGuid().ToString(),
                Name=brandsDto.Name,
                Pic=brandsDto.Image,
                Slug=brandsDto.Slug,
                InsertTime=DateTime.Now,
            };
          await  _context.Brands.AddAsync(brand);
          await  _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "موفق"
            };
        }
    }
    public class BrandsDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? Slug { get; set; }
        public string? Image { get; set; }
    }
    public class AddBrandViewDto
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Slug { get; set; }
        public string? Image { get; set; }
    }
}
