using EndPointStore.Areas.Admin.Models.ViewModelCategory;
using EndPointStore.Areas.Admin.Models.ViewModelFileManager;
using EndPointStore.Areas.Admin.Models.ViewModelProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.FileManager.Queries.ListDirectory;

using Store.Application.Services.Products.Category.Commands.GetParentCategory;
using Store.Application.Services.Products.Category.Queries.AddNewCategory;
using Store.Application.Services.Products.Queries.AddNewProduct;
using Store.Application.Services.Products.Tags.Commands.GetTagsList;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
  
    [Area("Admin")]
    public class ProductsController : Controller
    {
		private readonly IProductFacad _productFacad;
		public ProductsController(IProductFacad productFacad)
		{
			_productFacad = productFacad;
		}
		public async Task<IActionResult> Index()
        {
          
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> AddTag(string nameTag)
		{
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
			var resultTag =await _productFacad.AddTagService.Execute(nameTag);
			return Json(resultTag);
		}
        [HttpGet]
		public async Task<IActionResult> Create()
		{

			var listCategory = await _productFacad.GetParentCategory.Execute();
			var listBrands = await _productFacad.GetBrandListService.Execute();
			var listTags=await _productFacad.GetTagsListService.Execute();
			ViewModelProducts viewModelProducts = new ViewModelProducts()
			{
				AddNewProduct=new AddNewProductView(),
				Brands = listBrands,
				ParentCategory = listCategory
			};
			ViewBag.Category = new SelectList(listCategory, "Id", "Name");
			ViewBag.Brands= new SelectList(listBrands, "Id", "Name");
			ViewBag.Tags = new SelectList(listTags, "Id", "Name");
			return View(viewModelProducts);
		}
		[HttpGet]
		public async Task<IActionResult> GetListTags()
		{
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message =MessageInUser.IsValidForm
				});
			}
			var files = await _productFacad.GetTagsListService.Execute();
			return Json(new ResultDto<List<TagsListDto>> {
				Data=files,
				IsSuccess=true,
				Message=""
			});
		}
	}
}
