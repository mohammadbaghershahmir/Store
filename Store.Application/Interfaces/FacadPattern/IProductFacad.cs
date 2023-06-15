using Store.Application.Services.ProductsSite.Brands.Commands.GetBrandsList;
using Store.Application.Services.ProductsSite.Category.Commands.DeleteCategory;
using Store.Application.Services.ProductsSite.Category.Commands.GetCategory;
using Store.Application.Services.ProductsSite.Category.Commands.GetParentCategory;
using Store.Application.Services.ProductsSite.Category.Queries.AddNewCategory;
using Store.Application.Services.ProductsSite.Queries.AddNewProduct;
using Store.Application.Services.ProductsSite.Tags.Commands.GetTagsList;
using Store.Application.Services.ProductsSite.Tags.Queries.AddNewTag;
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
        IAddProductService AddProductService { get;}
    }
}
