using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.ProductsSite.Commands.AddNewCategory;
using Store.Application.Services.ProductsSite.Commands.AddNewProduct;
using Store.Application.Services.ProductsSite.Commands.AddNewTag;
using Store.Application.Services.ProductsSite.Commands.DeleteCategory;
using Store.Application.Services.ProductsSite.Commands.DeleteProducts;
using Store.Application.Services.ProductsSite.Commands.EditProducts;
using Store.Application.Services.ProductsSite.Queries.GetBrandsList;
using Store.Application.Services.ProductsSite.Queries.GetCategory;
using Store.Application.Services.ProductsSite.Queries.GetEditProductsList;
using Store.Application.Services.ProductsSite.Queries.GetParentCategory;
using Store.Application.Services.ProductsSite.Queries.GetProductsList;
using Store.Application.Services.ProductsSite.Queries.GetTagsList;
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
		private readonly IConfiguration _configuration;

		public ProductFacad(IDatabaseContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}
		private AddCategoryService _addCategoryService;
		private IGetCategory _getCategory;
		private IGetParentCategory _getParentCategory;
		private IDeleteCategory _deleteCategory;
		private IGetBrandListService _getBrandListService;
		private IAddTagService _addTagService;
		private IGetTagsListService _getTagsListService;
		private IAddProductService _addProductService;
		private IGetProductsListService _getProductsListService;
		private IRemoveProductService _removeProductService;
		private IGetEditProductListService _getEditProductListService;
		private IEditProductsService _getEditProductsService;
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
		//GetProducts List
		public IGetProductsListService GetProductsListService
		{
			get
			{
				return _getProductsListService = _getProductsListService ?? new GetProductsListService(_context, _configuration);
			}
		}
		//Remove Product
		public IRemoveProductService RemoveProductService
		{
			get
			{
				return _removeProductService = _removeProductService ?? new RemoveProductService(_context);
			}

		}
		//Get Edit Product
		public IGetEditProductListService GetEditProductListService
		{
			get
			{
				return _getEditProductListService = _getEditProductListService ?? new GetEditProductListService(_context, _configuration);
			}
		}

		public IEditProductsService EditProductsService
		{
			get
			{
				return _getEditProductsService = _getEditProductsService ?? new EditProductsService(_context);
			}
		}
	}
}
