using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Commands.CheckEmail;
using Store.Common.Constant;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Commands
{
    public class CheckMobileService : ICheckMobileExitsService
    {
        private readonly UserManager<User> _userManager;

        public CheckMobileService(UserManager<User> userManager)
        {
            _userManager=userManager;
        }

        public async Task<List<FindDtailMobileDto>> Execute(string Mobile, string Id)
        {
            var mobile = await _userManager.Users
                .Where(r => r.PhoneNumber == Mobile).ToListAsync();
            if (Id == null)
            {
                var listItem = mobile.Select(y => new FindDtailMobileDto()
                {
                    Mobile = y.PhoneNumber,
                    UserId = y.Id
                }).ToList();
                return listItem;
            }
            else
            {
                var listItem = mobile.Where(p => p.Id != Id).Select(y => new FindDtailMobileDto()
                {
                    Mobile = y.PhoneNumber,
                    UserId = y.Id
                }).ToList();
                return listItem;
            }

        }
    }
}
