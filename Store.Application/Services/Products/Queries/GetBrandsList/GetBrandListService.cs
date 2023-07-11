using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant.NoImage;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetBrandsList
{
    public class GetBrandListService : IGetBrandListService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        public GetBrandListService(IDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration= configuration;
        }
        public async Task<List<BrandsListDto>> Execute()
        {
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
           
            //Get List Brands
            var Brands = _context.Brands.Where(r=>r.IsRemoved==false).Select(b => new BrandsListDto
            {

                Name = b.Name,
                CssClass = b.CssClass,
                Id = b.Id,
                Pic = string.IsNullOrEmpty(b.Pic) ? ImageProductConst.NoImage:BaseUrl +b.Pic,
                Slug = b.Slug,
                Url= string.IsNullOrEmpty(b.Pic) ? ImageProductConst.NoImage:b.Pic,
                InsertTime =b.InsertTime
            }
            ).ToList().OrderByDescending(i=>i.InsertTime).ToList();
            return Brands;
        }
    }
}
