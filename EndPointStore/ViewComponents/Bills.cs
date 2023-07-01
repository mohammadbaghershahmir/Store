using EndPointStore.Utilities;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Carts;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "Bills")]
    public class Bills: ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly CookiesManager _cookiesManeger;
        public Bills(ICartService cartService)
        {
            _cartService = cartService;
            _cookiesManeger = new CookiesManager();
        }

        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            var cart = _cartService.GetBacket(_cookiesManeger.GetBrowserId(HttpContext), userId).Result.Data;
            return View(viewName: "Bills", cart);
        }
    }
}
