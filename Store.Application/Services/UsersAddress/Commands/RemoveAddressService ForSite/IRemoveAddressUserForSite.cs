using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.UsersAddress.Commands.RemoveAddressService_ForSite
{
    public interface IRemoveAddressUserForSite
    {
        Task<ResultDto> Execute(string AddressId);
    }
    public class RemoveAddressUserForSite : IRemoveAddressUserForSite
    {
        private readonly IDatabaseContext _context;
        public RemoveAddressUserForSite(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string AddressId)
        {
            var Address =await _context.UserAddresses.FindAsync(AddressId);
            if(Address==null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message=MessageInUser.NotFindAddressUser
                };
            }
            Address.IsRemoved=true;
            Address.RemoveTime=DateTime.Now;
           await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.RemoveAddress

            };
        }
    }
}
