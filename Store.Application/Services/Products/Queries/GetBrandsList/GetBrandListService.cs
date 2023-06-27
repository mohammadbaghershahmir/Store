using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
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
        public GetBrandListService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<BrandsDto>> Execute()
        {
            List<BrandsDto> ItemBrands = new List<BrandsDto>();
            ItemBrands.Add(new BrandsDto
            {
                Id = "",
                Name = "بدون انتخاب"
            });
            //Get List Brands
            var Brands = _context.Brands.Select(b => new BrandsDto
            {

                Name = b.Name,
                CssClass = b.CssClass,
                Id = b.Id,
                Pic = b.Pic,
                Slug = b.Slug
            }
            );
            ItemBrands.AddRange(Brands);
            return ItemBrands;
        }
    }
}
