using EndPointStore.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Carts;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "Cart")]
    public class Cart:ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly CookiesManager _cookiesManeger;
        public Cart(ICartService cartService)
        {
            _cartService = cartService;
            _cookiesManeger = new CookiesManager();
        }

        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), userId).Result.Data;
            return View(viewName: "Cart", cart);
        }
    }
}
