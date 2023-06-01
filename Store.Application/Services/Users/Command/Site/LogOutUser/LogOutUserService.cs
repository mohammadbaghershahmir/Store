using Microsoft.AspNetCore.Identity;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.Site.LogOutUser
{
    public class LogOutUserService : IlogOutUser
    {
        private readonly SignInManager<User> _signInManager;
        public LogOutUserService(SignInManager<User> signInManager)
        {
           _signInManager = signInManager;
        }
        public async Task<bool> Execute()
        {
          await  _signInManager.SignOutAsync();
            return true;
        }
    }
}
