using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Commands.CheckUser;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Commands
{
    public class CheckUserService : ICheckUserExitsService
    {
        private readonly UserManager<User> _userManager;
        public CheckUserService(UserManager<User> userManager)
        {
           _userManager = userManager;
        }
        public async Task<List<FindDtailUserDto>> Execute(string UserName)
        {
            var result = await _userManager.Users
                 .Where(r => r.UserName == UserName)
                 .Select(y => new FindDtailUserDto()
                 {
                     FullName = y.FullName,
                     UserId = y.Id,
                     IsActive = y.IsActive
                 }).ToListAsync();
            return result;
        }
    }
}
