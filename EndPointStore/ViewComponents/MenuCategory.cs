using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;

namespace EndPointStore.ViewComponents
{
    public class MenuCategory:ViewComponent
    {
        private readonly IGetCategorySiteService _getCategorySiteService;
        public MenuCategory(IGetCategorySiteService getCategorySiteService)
        {
            _getCategorySiteService = getCategorySiteService;
        }
        public  IViewComponentResult Invoke()
        {
            var menuCategory = _getCategorySiteService.Execute();
            return View(viewName:"MenuCategory", menuCategory.Result);
        }
    }
}

