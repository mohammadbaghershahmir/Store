using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Users.Command.RegisterUser;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Queries.GetUsers;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Queries.Edit
{
    public class GetEditUserService : IGetEditUserService
    {
        private readonly IDatabaseContext _context;
        public GetEditUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<EditUserDto> Execute(long Id)
        {
            var usrlist =await _context.Users.Include(p => p.Logins)
                .Include(p => p.Contacts)
                .Include(p => p.UserInRoles)
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();
            //Fill To Field
            return new EditUserDto
            {
                Id = Id,
                Name = usrlist.Name,
                LastName = usrlist.LastName,
                Gender = usrlist.Gender,   
                Mobile = usrlist.Contacts.Where(p => p.ContactTypeId == (long)ContactTypeEnum.Mobail).FirstOrDefault()?.Value,
                Email = usrlist.Contacts.Where(p => p.ContactTypeId == (long)ContactTypeEnum.Email).FirstOrDefault()?.Value,
                Phone = usrlist.Contacts.Where(p => p.ContactTypeId == (long)ContactTypeEnum.Phone).FirstOrDefault()?.Value,
                Address = usrlist.Contacts.Where(p => p.ContactTypeId == (long)ContactTypeEnum.Address).FirstOrDefault()?.Value,
                IsActive = usrlist.IsActive,
                IdesInRole = usrlist.UserInRoles.Select(i=>i.RoleId).ToArray()
            };
        }
    }
}
