using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.ProductsSite.Queries.GetDetailProductsForSite;
using Store.Common.Constant.NoImage;
using Store.Common.Constant.Settings;
using Store.Common.Dto;

namespace Store.Application.Services.ProductsSite.Queries.GetDetailProductModalForSite
{
    public class GetProductDetailModalSiteService : IGetProductDetailModalSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;

        public GetProductDetailModalSiteService(IDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ResultDto<DetailProductModalSiteDto>> Execute(string idProduct)
        {
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var lastWeekDate = DateTime.Now.AddDays(-7);
            var detailProductList = _context.Products.Include(it => it.ItemTags)
                 .ThenInclude(g => g.Tag).Include(i => i.Medias)
                 .Include(f => f.Features).
                 Include(b => b.Brands).Include(r => r.Rates).Where(r => r.Id == idProduct).FirstOrDefault();
            List<ImagesListDto> media = new List<ImagesListDto>();
            media.Add(new ImagesListDto() { Url = string.IsNullOrEmpty(detailProductList.Pic) ? ImageProductConst.NoImage : BaseUrl + detailProductList.Pic });
            var ListMedia = detailProductList.Medias.Select(n => new ImagesListDto { Url = string.IsNullOrEmpty(n.Src) ? "" : BaseUrl + n.Src }).ToList();
            media.AddRange(ListMedia);
            return new ResultDto<DetailProductModalSiteDto>
            {
                Data=new DetailProductModalSiteDto
                {
                    Id = detailProductList.Id,
                    Brand = detailProductList.Brands.Name,
                    CodeProduct = detailProductList.CodeProduct,
                    Unit=Settings.UnitText,
                    Description = string.IsNullOrEmpty(detailProductList.Description) ? "بدون توضیحات" :detailProductList.Description,
                    LastPrice = detailProductList.LastPrice,
                    Name = detailProductList.Name,
                    Price = detailProductList.Price,
                    NewProduct = detailProductList.InsertTime >= lastWeekDate ? true : false,
                    Discount =(float)Math.Round(((detailProductList.LastPrice-detailProductList.Price)/detailProductList.LastPrice)*100,1),
                    Star = detailProductList.Rates.Select(c => c.UserRate).FirstOrDefault(),
                    Tags = detailProductList.ItemTags.Select(c => new TagsListDto
                    {
                        Id = c.TagId,
                        Name = c.Tag.Name
                    }).ToList(),
                    UrlImagList =media
                },
                IsSuccess=true
            };
        }
    }
}
