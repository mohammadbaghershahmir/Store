using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Brands.Commands.GetBrandsList
{
	public interface IGetBrandListService
	{
		Task <List<BrandsDto>> Execute();
	}
}
