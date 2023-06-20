using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetProductsForSite
{
    public interface IGetProductsForSiteService
	{
        Task<ResultDto<ResultProductsForSiteDto>> Execute(int page);
	}
}
