using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Carts;
using Store.Application.Services.Posts.Queries;
using System.Xml.Linq;
using Store.Application.Services.UsersAddress.Queries.GetEditAddressUserForSite;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "EditProvince")]
    public class EditProvince : ViewComponent
    {
        private readonly IGetProvinceServices _getProvinceService;
        private readonly IGetCityService _getCityService;
        private readonly IGetEditAddressUserForSite _getEditAddressUserForSite;
        private readonly ICartService _cartService;

        public EditProvince(ICartService cartService, IGetProvinceServices getProvinceService, IGetEditAddressUserForSite getEditAddressUserForSite,
           IGetCityService getCityService)
        {
            _cartService = cartService;
            _getCityService = getCityService;
            _getProvinceService = getProvinceService;
            _getEditAddressUserForSite= getEditAddressUserForSite;
        }
        public  IViewComponentResult Invoke(RequestEditCityDto requestEdit)
        {
            var result=new EditAddressUserDto();
            ViewBag.EditProvince = new SelectList(_getProvinceService.Execute().Result.Data, "Id", "ProvinceName");
            if(requestEdit != null)
            {
                if (requestEdit.AddressId != null)
                {
                    result = _getEditAddressUserForSite.Execute(requestEdit).Result;
                }
            }
            return View(viewName: "EditProvince",result);
        }
    }
}
