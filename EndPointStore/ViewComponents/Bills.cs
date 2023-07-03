using EndPointStore.Utilities;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Carts;
using Store.Application.Services.Posts.Queries;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "Bills")]
    public class Bills: ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly CookiesManager cookiesManager;
        private readonly IGetCityForPayServices _getCityForPay;
        private readonly IGetCityService _getCityService;
        private readonly IGetProvinceServices _getProvinceService;

        public Bills(ICartService cartService,
            IGetCityForPayServices getCityForPay,
            IGetProvinceServices getProvinceService,
            IGetCityService getCityService)
        {
            _cartService = cartService;
            _getCityForPay = getCityForPay;
            _getCityService = getCityService;
            _getProvinceService = getProvinceService;
            cookiesManager = new CookiesManager();

        }
        public IViewComponentResult Invoke(string? cityId)
        {


            double costAllItem = 0;
            double costPost = 0;
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            var carts = _cartService.GetMyCart(cookiesManager.GetBrowserId(HttpContext), userId).Result.Data;
            if (carts.ProductCount > 0)
            {
                foreach (var item in carts.CartItems)
                {
                    double costitem = item.Count * item.Price;
                    costAllItem += costitem;
                }
            }
            ViewBag.costAllItem = costAllItem;
            ViewBag.costPost = costPost;
            ViewBag.costAll = costAllItem + costPost;
            return View(viewName: "Bills");
        }
    }
}
