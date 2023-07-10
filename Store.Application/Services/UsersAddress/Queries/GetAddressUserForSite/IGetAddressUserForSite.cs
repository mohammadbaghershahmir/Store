using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.UsersAddress.Queries.GetAddressUserForSite
{
    public interface IGetAddressUserForSite
    {
        Task<List<UserAddressDto>> Execute(string UserId);
    }
    public class GetAddressUserForSite : IGetAddressUserForSite
    {
        private readonly IDatabaseContext _context;
        public GetAddressUserForSite(IDatabaseContext context)
        {
            _context = context;   
        }
        public async Task<List<UserAddressDto>> Execute(string UserId)
        {
            var userAddress=await _context.UserAddresses.Include(p=>p.City).Where(t=>t.UserId==UserId)
            .Select(w=> new UserAddressDto
            {
                Id=w.Id,
            Address=w.Address,
            City=w.City.CityName,
            PhoneNumber=w.Phone,
            PostalCode=w.PostalCode,
            InsertTime=w.InsertTime,
            Province=w.City.ParrentId,
            Acitve=w.Active,
            }).OrderByDescending(r=>r.InsertTime).ToListAsync();
            return userAddress;
        }
    }
    public class UserAddressDto
    {
        public string Id { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Acitve { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
