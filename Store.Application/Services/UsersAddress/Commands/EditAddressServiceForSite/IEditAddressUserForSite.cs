using Store.Application.Interfaces.Contexs;
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
        Task<ResultDto> Execute(string IdAddressUser);
    }
    public class EditAddressUserForSite : IEditAddressUserForSite
    {
        private readonly IDatabaseContext _context;
        public EditAddressUserForSite(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string IdAddressUser)
        {
            var AddressUser =await _context.UserAddresses.FindAsync(IdAddressUser);
            return new ResultDto { IsSuccess=true};
        }
    }
}
