using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Commands.DeleteBrand
{
    public interface IRemoveBrandService
    {
        Task<ResultDto> Execute(string idBrand);
    }
    public class RemoveBrandService : IRemoveBrandService
    {
        private readonly IDatabaseContext _context;

        public RemoveBrandService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string idBrand)
        {
            var brand=_context.Brands.Find(idBrand);
            if(brand == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFindBrand
                };
            }
            //Remove Logical Products
            var products=_context.Products.Where(p => p.BrandId == brand.Id).ToList();
            foreach (var product in products)
            {
                product.BrandId = null;
            }
           await _context.SaveChangesAsync();
            brand.IsRemoved=true;
            brand.RemoveTime=DateTime.Now;
          await  _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.RemoveBrand
            };
        }
    }
}
