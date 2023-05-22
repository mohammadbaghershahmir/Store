using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Commands.CheckEmail;
using Store.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Commands
{
    public class CheckMobileService : ICheckMobileExitsService
    {
        private readonly IDatabaseContext _context;
        public CheckMobileService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<FindDtailMobileDto>> Execute(string Mobile,long id)
        {
            var Email = await _context.Contacts.Include(t => t.ContactType)
              .Where(r => r.Value == Mobile && r.ContactTypeId == (long)ContactTypeEnum.Mobail).ToListAsync();
            if (id == 0)
            {
                var listItem = Email.Select(y => new FindDtailMobileDto()
                {
                    Mobile = y.Value,
                    UserId = y.UserId
                }).ToList();
                return listItem;
            }
            else
            {
                var listItem = Email.Where(p => p.UserId != id).Select(y => new FindDtailMobileDto()
                {
                    Mobile = y.Value,
                    UserId = y.UserId
                }).ToList();
                return listItem;
            }
        }
    }
}
