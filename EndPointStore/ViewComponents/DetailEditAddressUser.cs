using EndPointStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Carts;
using Store.Application.Services.Posts.Queries;
using Store.Application.Services.UsersAddress.Queries.GetEditAddressUserForSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "DetailEditAddressUser")]
    public class DetailEditAddressUser:ViewComponent
    {
        private readonly IGetEditAddressUserForSite _getEditAddressUserForSite;
        public DetailEditAddressUser(IGetEditAddressUserForSite getEditAddressUserForSite)
        {
            _getEditAddressUserForSite = getEditAddressUserForSite;
        }
        public IViewComponentResult Invoke(EditCityViewComponentDto editCityViewComponentDto)
        {
            var result = new EditAddressUserDto();
            if (editCityViewComponentDto != null)
            {
                if (editCityViewComponentDto.AddressId != null)
                {
                    result = _getEditAddressUserForSite.Execute(editCityViewComponentDto.AddressId).Result;
                }
            }
            return View(viewName: "DetailEditAddressUser", result);
        }
    }
}
