using Store.Application.Interfaces.Contexs;
using Store.Application.Interfaces.FacadPattern;
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

namespace Store.Application.Services.ProductsSite.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDatabaseContext _context;
        public ProductFacad(IDatabaseContext context)
        {
            _context = context;
        }
        private AddCategoryService _addCategoryService;
        private IGetCategory _getCategory;
        private IGetParentCategory _getParentCategory;
        private IDeleteCategory _deleteCategory;
        private IGetBrandListService _getBrandListService;
        private IAddTagService _addTagService;
        private IGetTagsListService _getTagsListService;
        private IAddProductService _addProductService;
        //Add Category
        public AddCategoryService AddCategoryService
        {
            get { return _addCategoryService = _addCategoryService ?? new AddCategoryService(_context); }

        }
        //GetCategory
        public IGetCategory GetCategory
        {
            get
            {
                return _getCategory = _getCategory ?? new GetCategoryService(_context);
            }
        }
        //GetParrenCategory
        public IGetParentCategory GetParentCategory
        {
            get
            {
                return _getParentCategory = _getParentCategory ?? new GetParentCategory(_context);
            }
        }
        //DeleteCategory
        public IDeleteCategory GetDeleteCategory
        {
            get
            {
                return _deleteCategory = _deleteCategory ?? new DeleteCategoryService(_context);
            }
        }
		//GetBrands
		public IGetBrandListService GetBrandListService
		{
			get
			{
				return _getBrandListService = _getBrandListService ?? new GetBrandListService(_context);
			}
		}
        //AddTag
		public IAddTagService AddTagService
        {
			get
			{
				return _addTagService = _addTagService ?? new AddTagService(_context);
			}
		}
        //Get List Tags
		public IGetTagsListService GetTagsListService
        {
			get
			{
				return _getTagsListService = _getTagsListService ?? new GetTagsListService(_context);
			}
		}
        //Add Product
		public IAddProductService AddProductService
        {
			get
			{
				return _addProductService = _addProductService ?? new AddProductService(_context);
			}
		}
	}
}
