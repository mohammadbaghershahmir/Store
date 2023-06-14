using Store.Application.Services.Products.Brands.Commands.GetBrandsList;
using Store.Application.Services.Products.Category.Commands.DeleteCategory;
using Store.Application.Services.Products.Category.Commands.GetCategory;
using Store.Application.Services.Products.Category.Commands.GetParentCategory;
using Store.Application.Services.Products.Category.Queries.AddNewCategory;
using Store.Application.Services.Products.Tags.Commands.GetTagsList;
using Store.Application.Services.Products.Tags.Queries.AddNewTag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.FacadPattern
{
    public interface IProductFacad
    {
        AddCategoryService AddCategoryService { get;}
        IGetCategory GetCategory {  get;}
        IGetParentCategory GetParentCategory { get;}
        IDeleteCategory GetDeleteCategory { get;}
        IGetBrandListService GetBrandListService { get;}
        IAddTagService AddTagService { get;}
        IGetTagsListService GetTagsListService { get;}
    }
}
