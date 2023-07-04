using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.UsersAddress.Commands.AddAddressServiceForSite
{
    public interface IAddAddressServiceForSite
    {
        Task<ResultDto> Execute(RequestAddressDto requestAddress);
    }
    public class AddAddressServiceForSite : IAddAddressServiceForSite
    {
        private readonly IDatabaseContext _context;
        public AddAddressServiceForSite(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(RequestAddressDto requestAddress)
        {
            if (string.IsNullOrWhiteSpace(requestAddress.UserId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageUserNotLogin
                };
            }
            UserAddress userAddress = new UserAddress()
            {
                Id = Guid.NewGuid().ToString(),
                Address = requestAddress.Address,
                CityId = requestAddress.City,
                InsertTime = DateTime.Now,
                UserId = requestAddress.UserId,
                PostalCode = requestAddress.PostalCode,
                Phone = requestAddress.PhoneNumber
            };
            await _context.UserAddresses.AddAsync(userAddress);
            await _context.SaveChangesAsync();
            return new ResultDto { 
                IsSuccess = true,
                Message= MessageInUser.MessageUserAddressInsert
            };
        }
    }
    public class RequestAddressDto
    {
        public string UserId { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
