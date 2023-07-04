using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.UsersAddress.Queries.GetEditAddressUserForSite
{
    public interface IGetEditAddressUserForSite
    {
        Task<EditAddressUserDto> Execute(string IdAddressUser);
    }
    public class GetEditAddressUserForSite : IGetEditAddressUserForSite
    {
        private readonly IDatabaseContext _context;
        public GetEditAddressUserForSite(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<EditAddressUserDto> Execute(string IdAddressUser)
        {
            var listAddress =await _context.UserAddresses.Include(c=>c.City).Where(y=>y.Id==IdAddressUser).FirstOrDefaultAsync();
            return new EditAddressUserDto
            {

                Id = listAddress.Id,
                Address = listAddress.Address,
                City = new CityDto { Id = listAddress.City.Id, NameCity = listAddress.City.ParrentId != null ? listAddress.City.CityName : "" },
                PhoneNumber = listAddress.Phone,
                PostalCode = listAddress.PostalCode,
                Province = new ProvinceDto { Id = listAddress.City.Id, NameProvince = listAddress.City.ParrentId == null ? listAddress.City.CityName:""}
            };
        }
    }
    public class EditAddressUserDto
    {
        public string Id { get; set; }
        public ProvinceDto Province { get; set; }
        public CityDto City { get; set; }
        public int PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
    public class CityDto
    {
        public string  Id { get; set; }
        public string NameCity { get; set; }
    }
    public class ProvinceDto
    {
        public string? Id { get; set; }
        public string NameProvince { get; set; }
    }
}
