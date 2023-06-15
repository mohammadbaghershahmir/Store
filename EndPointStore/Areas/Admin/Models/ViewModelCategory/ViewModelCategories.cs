using Store.Application.Services.ProductsSite.Category.Commands.GetParentCategory;
using Store.Application.Services.ProductsSite.Category.Queries.AddNewCategory;

namespace EndPointStore.Areas.Admin.Models.ViewModelCategory
{
    public class ViewModelCategories
    {
        public List<ParentCategoryDto> ParentCategory {get;set;}
        public AddCategoryViewDto AddCategoryView { get; set; }
    }
}
