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

        public async Task<bool> Execute(string Mobile, string Id)
        {
            var mobile = _userManager.Users.Where(r=>r.PhoneNumber==Mobile).ToList();
            var user =  _userManager.FindByIdAsync(Id).Result;
            if (user == null && mobile.Count<=0&& Id == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
