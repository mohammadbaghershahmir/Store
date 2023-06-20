using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Common;
using Store.Common.Constant.NoImage;
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
        public async Task<ResultDto<ResultProductsForSiteDto>> Execute(int page)
		{
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            int totalRow = 0;
			var products = _context.Products.Include(r => r.Rates).ToPaged(page, 20, out totalRow);
			return new ResultDto<ResultProductsForSiteDto> {
				
				Data=new ResultProductsForSiteDto
				{
					TotalRow = totalRow,
					Products= products.Select(w => new ProductsForSiteDto
					{
						Id = w.Id,
						Image = string.IsNullOrEmpty(w.MinPic) ? ImageProductConst.NoImage :BaseUrl+w.MinPic,
                        Price = w.Price,
						LastPrice = w.LastPrice,
						Star = w.Rates.Select(e => e.UserRate).FirstOrDefault(),
						Title = w.Name
					}).ToList(),
				},
				IsSuccess=true
			};
		}
	}
}
