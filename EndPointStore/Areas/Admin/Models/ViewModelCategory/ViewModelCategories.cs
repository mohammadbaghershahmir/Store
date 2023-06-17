using Store.Application.Services.ProductsSite.Commands.AddNewCategory;
using Store.Application.Services.ProductsSite.Queries.GetParentCategory;

namespace EndPointStore.Areas.Admin.Models.ViewModelCategory
{
    public class ViewModelCategories
    {
        public List<ParentCategoryDto> ParentCategory {get;set;}
        public AddCategoryViewDto AddCategoryView { get; set; }
    }
}
