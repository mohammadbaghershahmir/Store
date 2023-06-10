using EndPointStore.Areas.Admin.Models.ViewModelFileManager;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.FileManager.Queries.ListDirectory;

namespace EndPointStore.Areas.Admin.Controllers
{
  
    [Area("Admin")]
    public class ProductsController : Controller
    {
      
        public async Task<IActionResult> Index()
        {
          
            return View();
        }
    }
}
