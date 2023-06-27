using FluentFTP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Common;
using Store.Common.Constant.FileTypeManager;
using Store.Common.Constant.NoImage;
using Store.Common.Constant.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetProductsList
{
    public class GetProductsListService : IGetProductsListService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;

        public GetProductsListService(IDatabaseContext context, IConfiguration configuration)
        {
            _context = context; 
            _configuration= configuration;
        }
        public async Task<ResultGetProductsDto> Execute(RequstGetProductsDto requstGetProducts)
        {
            try
            {
                string BaseUrl = _configuration.GetSection("BaseUrl").Value;
                var listProducts = _context.Products.Include(e => e.Category).AsQueryable();
                if(!string.IsNullOrEmpty(requstGetProducts.SearchKey))
                {
                    listProducts = listProducts.Where(e => e.Name.Contains(requstGetProducts.SearchKey));
                }
                int RowsCount = 0;
                var Products=listProducts.ToPaged(requstGetProducts.Page,20, out RowsCount)
                     .Select(
                p => new ProductsListDto
                {
                    Id = p.Id,
                    Category = p.Category?.Name,
                    IsActive = p.IsActive,
                    Name = p.Name,
                    Pic = string.IsNullOrEmpty(p.MinPic) ? ImageProductConst.NoImage : BaseUrl + p.MinPic,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    InsertTime = p.InsertTime
                }
                ).ToList().OrderByDescending(i => i.InsertTime).ToList();
                return new ResultGetProductsDto(){
                Products = Products,
                Rows= RowsCount,
                };
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
