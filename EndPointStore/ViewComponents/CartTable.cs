using EndPointStore.Utilities;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Carts;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "CartTable")]
    public class CartTable : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly CookiesManager cookiesManager;
        public CartTable(ICartService cartService)
        {
            _cartService = cartService;
            cookiesManager = new CookiesManager();
        }
        public  IViewComponentResult Invoke()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            return View(viewName: "CartTable",_cartService.GetMyCart(cookiesManager.GetBrowserId(HttpContext), userId).Result.Data);
        }
    }
}
