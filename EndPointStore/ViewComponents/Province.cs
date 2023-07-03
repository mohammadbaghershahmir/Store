using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Carts;
using Store.Application.Services.Posts.Queries;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "Province")]
    public class Province : ViewComponent
    {
        private readonly IGetProvinceServices _getProvinceService;
        private readonly IGetCityService _getCityService;
        private readonly ICartService _cartService;

        public Province(ICartService cartService, IGetProvinceServices getProvinceService,
           IGetCityService getCityService)
        {
            _cartService = cartService;
            _getCityService = getCityService;
            _getProvinceService = getProvinceService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.province = new SelectList(_getProvinceService.Execute().Result.Data, "Id", "ProvinceName");
            return View(viewName: "Province");
        }
    }
}