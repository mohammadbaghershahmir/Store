using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Users.Command.RegisterUser;
using Store.Application.Services.Users.Queries.Edit;
using Store.Common.Constant;
using Store.Common.Constant.Roles;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Store.Application.Services.Users.Command.EditUser
{
    public class EditUserService : IEditUserService
    {
        private readonly IDatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;  
        public EditUserService(IDatabaseContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ResultDto> Execute(EditUserDto EditUserService)
        {
            var usrlist = await _userManager.FindByIdAsync(EditUserService.Id);
            //Chck Null ListUser
            if (usrlist == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageNotFind
                };
            }
            //Add UsersEdit
            usrlist.FirstName = EditUserService.Name;
            usrlist.LastName = EditUserService.LastName;
            usrlist.FullName = EditUserService.Name + " " + EditUserService.LastName;
            usrlist.IsActive = EditUserService.IsActive;
            usrlist.Gender = EditUserService.Gender;
            usrlist.UpdateTime = DateTime.Now;
            //Add contact
            usrlist.Email = EditUserService.Email;
            usrlist.PhoneNumber = EditUserService.Mobile;
            //Add UserInRole
          var rolePast= await _userManager.GetRolesAsync(usrlist);
            await _userManager.RemoveFromRolesAsync(usrlist, rolePast);
            await _userManager.AddToRolesAsync(usrlist, EditUserService.IdesInRole);
            await _userManager.UpdateAsync(usrlist);
            //Show Result
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageUpdate
            };
        }
    }
}
