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
            var listAddress = _context.UserAddresses.Include(c => c.City).Where(y => y.Id == IdAddressUser).FirstOrDefault();
            var cityFromProvince = _context.Provinces.Where(r => r.ParrentId == listAddress.City.ParrentId);
            return new EditAddressUserDto
            {

                Id = listAddress.Id,
                Address = listAddress.Address,
                City =cityFromProvince.Select(q => new CityAddressDto
                {
                    CityName = q.CityName,
                    Id = q.Id,
                }
                ).ToList(),
                PhoneNumber = listAddress.Phone,
                PostalCode = listAddress.PostalCode,
                Province = listAddress.City.ParrentId,
                CityAcitve=listAddress.CityId,
            };

        }
    }
    public class EditAddressUserDto
    {
        public string Id { get; set; }
        public string? Province { get; set; }
        public List<CityAddressDto> City { get; set; }
        public string CityAcitve { get; set; }
        public int PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
    public class CityAddressDto
    {
        public string Id { get; set; }
        public string CityName { get; set; }
    }
}
