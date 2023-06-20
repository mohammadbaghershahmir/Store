using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;

namespace Store.Application.Services.ProductsSite.Queries.GetDetailProductsForSite
{
    public class GetDetailProductSiteService:IGetDetailProductSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;

        public GetDetailProductSiteService(IDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<DetailProductSiteDto> Execute(string idProduct)
        {
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var detailProductList = _context.Products.Include(it => it.ItemTags)
                 .ThenInclude(g => g.Tag).Include(i => i.Medias)
                 .Include(f => f.Features).
                 Include(b => b.Brands).Include(r => r.Rates).Where(r=>r.Id==idProduct).FirstOrDefault();
                return new DetailProductSiteDto
                {
                    Id = detailProductList.Id,
                    Brand = detailProductList.Brands.Name,
                    CodeProduct = 0,
                    Description = detailProductList.Description,
                    FeatureList = detailProductList.Features.Select(q => new FeatureListDto { Title = q.DisplayName, Value = q.Value }).ToList(),
                    LastPrice = detailProductList.LastPrice,
                    Name = detailProductList.Name,
                    Price = detailProductList.Price,
                    Star = detailProductList.Rates.Select(c => c.UserRate).FirstOrDefault(),
                    Tags = detailProductList.ItemTags.Select(c => new TagsListDto
                    {
                        Id = c.TagId,
                        Name = c.Tag.Name
                    }).ToList(),
                    UrlImagList = detailProductList.Medias.Select(n => new ImagesListDto { Url =BaseUrl+n.Src }).ToList()

                };
        }
    }
}
