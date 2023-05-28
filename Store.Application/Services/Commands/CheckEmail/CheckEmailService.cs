using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Commands.CheckEmail
{
    public class CheckEmailService : ICheckEmailService
    {
        private readonly UserManager<User> _userManager;
       
        public CheckEmailService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<FindDtailEmailDto>> Execute(string Email, string Id)
        {
            var email = await _userManager.Users
                .Where(r => r.Email == Email).ToListAsync();
            if (Id == null)
            {
                var listItem = email.Select(y => new FindDtailEmailDto()
                {
                    Email = y.Email,
                    UserId = y.Id
                }).ToList();
                return listItem;
            }
            else
            {
                var listItem = email.Where(p => p.Id != Id).Select(y => new FindDtailEmailDto()
                {
                    Email = y.Email,
                    UserId = y.Id
                }).ToList();
                return listItem;
            }

        }
    }
}
