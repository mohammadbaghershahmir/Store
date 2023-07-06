using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Carts;
using Store.Application.Services.Posts.Queries;
using System.Xml.Linq;
using Store.Application.Services.UsersAddress.Queries.GetEditAddressUserForSite;
using EndPointStore.Controllers;

namespace EndPointStore.ViewComponents
{
	[ViewComponent(Name = "EditCity")]
	public class EditCity : ViewComponent
	{
		private readonly IGetProvinceServices _getProvinceService;
		private readonly IGetCityService _getCityService;
		private readonly ICartService _cartService;
		private readonly IGetEditAddressUserForSite _getEditAddressUserForSite;
		public EditCity(ICartService cartService, IGetProvinceServices getProvinceService,
		   IGetCityService getCityService, IGetEditAddressUserForSite getEditAddressUserForSite)
		{
			_cartService = cartService;
			_getCityService = getCityService;
			_getProvinceService = getProvinceService;
			_getEditAddressUserForSite = getEditAddressUserForSite;
		}
		public IViewComponentResult Invoke(EditCityViewComponentDto editCityViewComponentDto)
		{
			var result = new EditAddressUserDto();
            if (editCityViewComponentDto!=null)
			{
				if (editCityViewComponentDto.AddressId != null)
				{
					result = _getEditAddressUserForSite.Execute(editCityViewComponentDto.AddressId).Result;
					ViewBag.EditCity = new SelectList(result.City, "Id", "CityName");
				}
            }
			return View(viewName: "EditCity",result);
		}
	}
}
