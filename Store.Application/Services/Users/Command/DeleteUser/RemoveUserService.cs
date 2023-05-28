using Microsoft.AspNetCore.Identity;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.DeleteUser
{
    public class RemoveUserService : IRemoveService
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly UserManager<User> _userManager;
        public RemoveUserService(IDatabaseContext removeService, UserManager<User> userManager)
        {
            _databaseContext = removeService;
            _userManager = userManager;
        }
        public async Task<ResultDto> Execute(string Id)
        {
            var user =  _userManager.FindByIdAsync(Id).Result;
            //Find User
            if (user == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageNotFind
                };
            }
            //Remove Logical
            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
           await _userManager.UpdateAsync(user);
            //Show Result
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageDelete
            };

        }
    }
}
