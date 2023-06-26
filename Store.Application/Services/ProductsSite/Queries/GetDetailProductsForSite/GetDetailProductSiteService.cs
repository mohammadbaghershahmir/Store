using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant.Settings;

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
            var lastWeekDate = DateTime.Now.AddDays(-7);
            var detailProductList =await _context.Products.Include(it => it.ItemTags)
                 .ThenInclude(g => g.Tag).Include(i => i.Medias)
                 .Include(f => f.Features).
                 Include(b => b.Brands).Include(r => r.Rates).Where(r=>r.Id==idProduct).FirstOrDefaultAsync();
            if (detailProductList == null) { }
              detailProductList.ViewCount++;
            await _context.SaveChangesAsync();
                return new DetailProductSiteDto
                {
                    Id = detailProductList.Id,
                    Brand = detailProductList.Brands.Name,
                    CodeProduct = detailProductList.CodeProduct,
                    Content = detailProductList.Content,
                    Description = detailProductList.Description,
                    Unit=Settings.UnitText,
                    FeatureList = detailProductList.Features.Select(q => new FeatureListDto { Title = q.DisplayName, Value = q.Value }).ToList(),
                    LastPrice = detailProductList.LastPrice,
                    Name = detailProductList.Name,
                    Price = detailProductList.Price,
                    NewProduct = detailProductList.InsertTime >= lastWeekDate ? true : false,
                    Discount = (float)Math.Round(((detailProductList.LastPrice - detailProductList.Price) / detailProductList.LastPrice) * 100, 1),
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
