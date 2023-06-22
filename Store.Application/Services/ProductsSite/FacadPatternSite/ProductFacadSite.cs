using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.ProductsSite.Queries.GetCategory;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;
using Store.Application.Services.ProductsSite.Queries.GetDetailProductModalForSite;
using Store.Application.Services.ProductsSite.Queries.GetDetailProductsForSite;
using Store.Application.Services.ProductsSite.Queries.GetProductsForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.FacadPatternSite
{
	public class ProductFacadSite:IProductFacadSite
	{
		private readonly IDatabaseContext _context;
		private readonly IConfiguration _configuration;

		public ProductFacadSite(IDatabaseContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}
		private IGetProductsForSiteService _getProductsForSiteService;
		private IGetDetailProductSiteService _getDetailProductSiteService;
		private IGetProductDetailModalSiteService _getDetailProductModalSiteService;
		//Get Products For Site
		public IGetProductsForSiteService GetProductsForSiteService
		{
			get
			{
				return _getProductsForSiteService = _getProductsForSiteService ?? new GetProductsForSiteService(_context,_configuration);
			}
		}
        //Get Detail Product Site
        public IGetDetailProductSiteService GetDetailProductSiteService
		{
            get
            {
                return _getDetailProductSiteService = _getDetailProductSiteService ?? new GetDetailProductSiteService(_context,_configuration);
            }
        }

        public IGetProductDetailModalSiteService DetailProductModalSiteService
		{
            get
            {
                return _getDetailProductModalSiteService = _getDetailProductModalSiteService ?? new GetProductDetailModalSiteService(_context, _configuration);
            }
        }
    }
}
