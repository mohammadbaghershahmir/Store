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

        public async Task<List<FindDtailEmailDto>> Execute(string email, long id)
        {
            var Email = await _context.Contacts.Include(t => t.ContactType)
                .Where(r => r.Value == email && r.ContactTypeId == (long)ContactTypeEnum.Email).ToListAsync();
            if (id == 0)
            {
                var listItem = Email.Select(y => new FindDtailEmailDto()
                {
                    Email = y.Value,
                    IdUser = y.UserId
                }).ToList();
                return listItem;
            }
            else
            {
                var listItem = Email.Where(p => p.UserId != id).Select(y => new FindDtailEmailDto()
                {
                    Email = y.Value,
                    IdUser = y.UserId
                }).ToList();
                return listItem;
            }

        }
    }
}
