using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Controllers
{
    public class ProductsController : Controller
    {
		private readonly IProductFacadSite _productFacadSite;
		public ProductsController(IProductFacadSite productFacadSite)
		{
			_productFacadSite = productFacadSite;
		}
		public async Task<IActionResult> Index(string? SearchKey,int page=1)
        {
			var result = await _productFacadSite.GetProductsForSiteService.Execute(SearchKey,page);
            return View(result.Data);
        }
		public async Task<IActionResult> Detail(string Id)
		{
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var resultDetail=await _productFacadSite.GetDetailProductSiteService.Execute(Id);
			return View(resultDetail);
		}
        [HttpPost]
        public async Task<IActionResult> GetProductDetail(string productId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _productFacadSite.DetailProductModalSiteService.Execute(productId);
            return Json(result);
        }
    }
}
