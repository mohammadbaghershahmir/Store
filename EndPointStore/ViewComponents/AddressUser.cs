using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Carts;
using Store.Application.Services.Posts.Queries;
using System.Xml.Linq;
using Store.Application.Services.UsersAddress.Commands.AddAddressServiceForSite;
using Store.Application.Services.UsersAddress.Queries.GetAddressUserForSite;
using EndPointStore.Utilities;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "AddressUser")]
    public class AddressUser : ViewComponent
    {
        private readonly IGetAddressUserForSite _getAddressServiceForSite;
        public AddressUser(IGetAddressUserForSite GetAddressServiceForSite)
        {
            _getAddressServiceForSite = GetAddressServiceForSite;
        }
        public IViewComponentResult Invoke(string provinceId)
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            var AddressUser = _getAddressServiceForSite.Execute(userId);
            return View(viewName: "AddressUser",AddressUser.Result);
        }
    }
}
