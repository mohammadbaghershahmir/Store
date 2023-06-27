using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetEditProductsList
{
    public class GetEditProductListService : IGetEditProductListService
    {
        private readonly IDatabaseContext _context;
		private readonly IConfiguration _configuration;
		public GetEditProductListService(IDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<EditProductListDto> Execute(string productId)
        {
            try
            {
				string BaseUrl = _configuration.GetSection("BaseUrl").Value;
				var productList = _context.Products.Include(e => e.Features).Include(w => w.Medias).Include(i => i.ItemTags).AsQueryable();
                var product = productList.Where(p => p.Id == productId).FirstOrDefault();
                return new EditProductListDto
                {
                    Id = product.Id,
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    Content = product.Content,
                    Description=product.Description,
                    FeatureList = product.Features.Select(p => new FeatureListDto { Title = p.DisplayName, Value = p.Value }).ToList(),
                    IsActive = product.IsActive,
                    LastPrice = product.LastPrice,
                    MinPic = product.MinPic,
                    Name = product.Name,
                    Pic = product.Pic,
                    PostageFee = product.PostageFee,
                    PostageFeeBasedQuantity = product.PostageFeeBasedQuantity,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Slug = product.Slug,
                    TagsId = product.ItemTags.Select(i => i.TagId).ToArray(),
                    UrlImagList =product.Medias.Select(m => m.Src).ToArray(),
                    UserId = product.UserId,
                    BaseUrl= BaseUrl
				};
            }
            catch (Exception)
            {

                throw;
            }
         
        }
    }
}
