using EndPointStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using System.Diagnostics;

namespace EndPointStore.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IProductFacad _productFacad;
		public HomeController(ILogger<HomeController> logger, IProductFacad productFacad)
        {
            _logger = logger;
            _productFacad = productFacad;
        }
        public async Task<IActionResult> Index()
        {
            var categories =await _productFacad.GetParentCategory.Execute();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}