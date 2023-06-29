using Microsoft.AspNetCore.Mvc;

namespace EndPointStore.ViewComponents
{
    public class Search : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(viewName: "Search");
        }
   }
}
