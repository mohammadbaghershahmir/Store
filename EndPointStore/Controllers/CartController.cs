using EndPointStore.Utilities;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Carts;

namespace EndPointStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService  _cartService;
        private readonly CookiesManager cookiesManager;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
            cookiesManager = new CookiesManager();
        }
        public async Task<IActionResult> GetMyCart()
        {
            var userId = ClaimUtility.GetUserId(User);
            var resultCart =await _cartService.GetMyCart(cookiesManager.GetBrowserId(HttpContext), userId, false);
            return Json(resultCart.Data);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(string productId, int? count)
        {
            var result =await _cartService.AddToCard(productId, cookiesManager.GetBrowserId(HttpContext),count);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(string CartItemId)
        {
          var resultAdd= await _cartService.AddCount(CartItemId);
            return Json(resultAdd);
        }
        [HttpPost]
        public async Task<IActionResult> LowOff(string CartItemId)
        {
            var resultLow = await _cartService.MinCount(CartItemId);
            return Json(resultLow);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCard(string ProductId)
        {
            var resultRemove = await _cartService.RemoveFromCard(ProductId, cookiesManager.GetBrowserId(HttpContext));
            return Json(resultRemove);
        }
        public async Task<IActionResult> Remove(string ProductId)
        {
            var resultRemove = await _cartService.Remove(ProductId);
            return Json(resultRemove);
        }
    }
}
