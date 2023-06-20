using Store.Application.Services.ProductsSite.Queries.GetDetailProductsForSite;
using Store.Application.Services.ProductsSite.Queries.GetProductsForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.FacadPatternSite
{
	public interface IProductFacadSite
	{
		IGetProductsForSiteService GetProductsForSiteService {  get; }
		IGetDetailProductSiteService GetDetailProductSiteService { get; }
	}
}
