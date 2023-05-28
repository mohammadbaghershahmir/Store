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

        public async Task<bool> Execute(string Email, string Id)
        {
            var email =  _userManager.FindByEmailAsync(Email).Result;
            var user= _userManager.FindByIdAsync(Id).Result;
            if(user==null&&email==null&&Id==null)
            {
                return false;
            }
           else
            {
              return  true;
            }
           
        }
    }
}
