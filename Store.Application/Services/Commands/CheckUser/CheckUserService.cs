using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Commands.CheckUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Commands
{
    public class CheckUserService : ICheckUserExitsService
    {
        private readonly IDatabaseContext _context;
        public CheckUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<FindDtailUserDto>> Execute(string UserName)
        {
            var result = await _context.Logins.Include(t => t.User)
                .Where(r => r.UserName == UserName)
                .Select(y => new FindDtailUserDto()
                {

                    FullName = y.User.FullName,
                    UserId = y.User.Id,
                    IsActive = y.User.IsActive
                }).ToListAsync();
            return result;
        }
    }
}
