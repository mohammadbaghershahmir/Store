using Store.Application.Services.Products.Brands.Commands.GetBrandsList;
using Store.Application.Services.Products.Category.Commands.GetParentCategory;
using Store.Application.Services.Products.Queries.AddNewProduct;
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
