using Store.Application.Services.ProductsSite.Commands.AddNewProduct;
using Store.Application.Services.ProductsSite.Queries.GetBrandsList;
using Store.Application.Services.ProductsSite.Queries.GetParentCategory;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Models.ViewModelProduct
{
    public class ViewModelProducts
	{
		public AddNewProductView AddNewProduct { get;set; }
		public List<ParentCategoryDto> ParentCategory { get; set; }
		public List<BrandsDto> Brands { get; set; }
	}
}
