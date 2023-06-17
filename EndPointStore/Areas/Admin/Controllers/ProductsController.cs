﻿using EndPointStore.Areas.Admin.Models.ViewModelCategory;
using EndPointStore.Areas.Admin.Models.ViewModelFileManager;
using EndPointStore.Areas.Admin.Models.ViewModelProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.ProductsSite.Commands.AddNewProduct;
using Store.Application.Services.ProductsSite.Queries.GetProductsList;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Application.Services.ProductsSite.Queries.GetTagsList;
using Store.Application.Services.Users.Command.DeleteUser;

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
		[HttpGet]
		public async Task<IActionResult> Index(string searchkey, int page = 1)
        {
			var listProducts =await _productFacad.GetProductsListService.Execute(	
				new RequstGetProductsDto
				{
					SearchKey = searchkey,
					Page=page
				}
				);
            return View(listProducts);
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
		[HttpPost]
		public async Task<IActionResult> Create(AddNewProductView product)
		{
			if(!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
			var resultProduct =await _productFacad.AddProductService.Execute(
				new RequestAddProductDto
				{
					Name = product.Name,
					Price=product.Price,
					Quantity=product.Quantity,
					PostageFee=product.PostageFee,
					PostageFeeBasedQuantity=product.PostageFeeBasedQuantity,
					Slug=product.Slug,
					IsActive=product.IsActive,
					MinPic=product.MinPic,
					Pic=product.Pic,
					Content=product.Content,
					CategoryId=product.CategoryId,
					BrandId=product.BrandId,
					UserId=product.UserId,
					TagsId=product.TagsId,
					FeatureList=product.FeatureList,
					UrlImagList=product.UrlImagList,
				}
				);
			return Json(resultProduct);
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
        [HttpPost]
        public async Task<IActionResult> Delete(string? ProductId)
        {
			var resultRemove = await _productFacad.RemoveProductService.Execute(ProductId);
            return Json(resultRemove);
        }
    }
}