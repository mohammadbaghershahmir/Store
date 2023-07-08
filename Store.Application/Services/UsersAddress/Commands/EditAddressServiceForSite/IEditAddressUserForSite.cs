using Store.Application.Interfaces.Contexs;
using Store.Application.Services.UsersAddress.Queries.GetEditAddressUserForSite;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.UsersAddress.Commands.EditAddressServiceForSite
{
    public interface IEditAddressUserForSite
    {
        Task<ResultDto> Execute(RequestEditAddressUserDto requestEdit);
    }
    public class EditAddressUserForSite : IEditAddressUserForSite
    {
        private readonly IDatabaseContext _context;
        public EditAddressUserForSite(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(RequestEditAddressUserDto  requestEdit)
        {
            var AddressUser =await _context.UserAddresses.FindAsync(requestEdit.Id);
            if (AddressUser == null)
            {
                return new ResultDto()
                {
                    IsSuccess=false,
                    Message=MessageInUser.NotFind
                };
            }
            //Edit Address
            AddressUser.Address = requestEdit.Address;
            AddressUser.Phone = requestEdit.PhoneNumber;
            AddressUser.PostalCode = requestEdit.PostalCode;
            AddressUser.UpdateTime = DateTime.Now;
            await  _context.SaveChangesAsync();
            //Edit Province And City
            var cityExits = _context.Provinces.Where(w => w.ParrentId != null && w.Id == requestEdit.City).FirstOrDefault();
            if (cityExits != null)
            {
                AddressUser.CityId = cityExits.Id;
                await _context.SaveChangesAsync();
            }
            var provinceExits=_context.Provinces.Where(q=>q.ParrentId==null&&q.Id==requestEdit.Province).FirstOrDefault();
            if (provinceExits != null)
            {
                provinceExits.Id = requestEdit.Province;
                await _context.SaveChangesAsync();
            }
            return new ResultDto() {
            IsSuccess=true,
            Message=MessageInUser.MessageUserAddressUpdate
            };
        }
    }
    public class RequestEditAddressUserDto
    {
        public string Id { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
