using Store.Application.Interfaces.Contexs;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Products.Category.Commands.DeleteCategory;
using Store.Application.Services.Products.Category.Commands.GetCategory;
using Store.Application.Services.Products.Category.Commands.GetParentCategory;
using Store.Application.Services.Products.Category.Queries.AddNewCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Category.FacadPattern
{
    public class ProductFacad:IProductFacad
    {
        private readonly IDatabaseContext _context;
        public ProductFacad(IDatabaseContext context )
        {
            _context = context;
        }
        private AddCategoryService _addCategoryService;
        private IGetCategory _getCategory;
        private IGetParentCategory _getParentCategory;
        private IDeleteCategory _deleteCategory;
        public AddCategoryService AddCategoryService
        { 
        get { return _addCategoryService=_addCategoryService??new AddCategoryService(_context);}

        }
        public IGetCategory GetCategory
        {
            get
            {
                return _getCategory=_getCategory ?? new GetCategoryService(_context);
            }
        }
        public IGetParentCategory GetParentCategory
        {
            get
            {
                return _getParentCategory= _getParentCategory ?? new GetParentCategory(_context);
            }
        }
        public IDeleteCategory GetDeleteCategory
        {
            get
            {
                return _deleteCategory = _deleteCategory ?? new DeleteCategoryService(_context);
            }
        }
    }
}
