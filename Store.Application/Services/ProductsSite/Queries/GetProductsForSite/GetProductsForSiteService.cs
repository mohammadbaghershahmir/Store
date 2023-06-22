using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Common;
using Store.Common.Constant.NoImage;
using Store.Common.Constant.Settings;
using Store.Common.Dto;

namespace Store.Application.Services.ProductsSite.Queries.GetProductsForSite
{
    public class GetProductsForSiteService : IGetProductsForSiteService
	{
		private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        public GetProductsForSiteService(IDatabaseContext context, IConfiguration configuration)
        {
			_context = context;
			_configuration = configuration;
        }
        public async Task<ResultDto<ResultProductsForSiteDto>> Execute( string SearchKey, int page)
		{
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            int totalRow = 0;
            DateTime lastWeekDate = DateTime.Now.AddDays(-7);
            var products = _context.Products.Include(r => r.Rates).Include(b=>b.Brands).Include(c=>c.Category).AsQueryable();
			if(!string.IsNullOrWhiteSpace(SearchKey) )
			{
				products = _context.Products.Where(n => n.Name.Contains(SearchKey) || n.Brands.Name.Contains(SearchKey) || n.Category.Name.Contains(SearchKey)).AsQueryable();
			}
			return new ResultDto<ResultProductsForSiteDto> {

				Data = new ResultProductsForSiteDto
				{
					TotalRow = totalRow,
					Products = products.Select(w => new ProductsForSiteDto
					{
						Id = w.Id,
						Image = string.IsNullOrEmpty(w.MinPic) ? ImageProductConst.NoImage : BaseUrl + w.MinPic,
						Price = w.Price,
						Unit = Settings.UnitText,
						LastPrice = w.LastPrice,
						//Discount = (float)((w.LastPrice - w.Price) / w.LastPrice) * 100,
						Star = w.Rates.Select(e => e.UserRate).FirstOrDefault(),
						NewProduct = w.InsertTime >= lastWeekDate ?true:false,
						Title = w.Name
					}).ToPaged(page, 20, out totalRow).ToList(),
				},
				IsSuccess=true
			};
		}
	}
}
