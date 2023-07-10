using Store.Application.Services.Products.Commands.AddNewBrand;
using Store.Application.Services.ProductsSite.Commands.AddNewCategory;
using Store.Application.Services.ProductsSite.Queries.GetBrandsList;

namespace EndPointStore.Areas.Admin.Models.ViewModelBrand
{
    public class ViewModelBrand
    {
        public List<BrandsListDto> BrandsLists { get; set; }
        public AddBrandViewDto AddBrandView { get; set; }
    }
}
