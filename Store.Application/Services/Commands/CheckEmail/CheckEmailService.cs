using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
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
        private readonly IDatabaseContext _context;
        public CheckEmailService(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<FindDtailEmailDto>> Execute(string Email, long Id)
        {
            var email = await _context.Contacts.Include(t => t.ContactType)
                .Where(r => r.Value == Email && r.ContactTypeId == (long)ContactTypeEnum.Email).ToListAsync();
            if (Id == 0)
            {
                var listItem = email.Select(y => new FindDtailEmailDto()
                {
                    Email = y.Value,
                    UserId = y.UserId
                }).ToList();
                return listItem;
            }
            else
            {
                var listItem = email.Where(p => p.UserId != Id).Select(y => new FindDtailEmailDto()
                {
                    Email = y.Value,
                    UserId = y.UserId
                }).ToList();
                return listItem;
            }

        }
    }
}
