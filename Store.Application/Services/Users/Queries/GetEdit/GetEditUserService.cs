using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Users.Command.RegisterUser;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Queries.GetUsers;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
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
        private readonly UserManager<User> _userManager;
        
        public GetEditUserService(IDatabaseContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
           
        }
        public async Task<EditUserDto> Execute(string Id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(Id);
                var listRol = await _userManager.GetRolesAsync(user);
                //Fill To Field
                return new EditUserDto
                {
                    Id = Id,
                    Name = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    Mobile = user.PhoneNumber,
                    Email = user.Email,
                    //Phone = usrlist.Contacts.Where(p => p.ContactTypeId == (long)ContactTypeEnum.Phone).FirstOrDefault()?.Value,
                    //Address = usrlist.Contacts.Where(p => p.ContactTypeId == (long)ContactTypeEnum.Address).FirstOrDefault()?.Value,
                    IsActive = user.IsActive,
                    IdesInRole = listRol.ToArray()
                };
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
