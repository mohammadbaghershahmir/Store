using Store.Application.Services.ProductsSite.Commands.AddNewCategory;
using Store.Application.Services.ProductsSite.Commands.AddNewProduct;
using Store.Application.Services.ProductsSite.Commands.AddNewTag;
using Store.Application.Services.ProductsSite.Commands.DeleteCategory;
using Store.Application.Services.ProductsSite.Commands.DeleteProducts;
using Store.Application.Services.ProductsSite.Queries.GetBrandsList;
using Store.Application.Services.ProductsSite.Queries.GetCategory;
using Store.Application.Services.ProductsSite.Queries.GetParentCategory;
using Store.Application.Services.ProductsSite.Queries.GetProductsList;
using Store.Application.Services.ProductsSite.Queries.GetTagsList;
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
        IGetProductsListService GetProductsListService { get;}
        IRemoveProductService RemoveProductService { get;}
    }
}
