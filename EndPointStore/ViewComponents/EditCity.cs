using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Carts;
using Store.Application.Services.Posts.Queries;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
	[ViewComponent(Name = "EditCity")]
	public class EditCity : ViewComponent
	{
		private readonly IGetProvinceServices _getProvinceService;
		private readonly IGetCityService _getCityService;
		private readonly ICartService _cartService;

		public EditCity(ICartService cartService, IGetProvinceServices getProvinceService,
		   IGetCityService getCityService)
		{
			_cartService = cartService;
			_getCityService = getCityService;
			_getProvinceService = getProvinceService;
		}
		public IViewComponentResult Invoke(string provinceId)
		{
			ViewBag.city = new SelectList(_getCityService.Execute(provinceId).Result.Data, "Id", "CityName");
			return View(viewName: "EditCity");
		}
	}
}
