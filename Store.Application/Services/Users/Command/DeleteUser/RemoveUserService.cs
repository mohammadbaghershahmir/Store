using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
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
        public RemoveUserService(IDatabaseContext removeService)
        {
            _databaseContext = removeService;
        }
        public async Task<ResultDto> Execute(long id)
        {
            var user =await _databaseContext.Users.FindAsync(id);
            if(user == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message=MessageInUser.MessageNotFind
                };
            }
           user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
           await _databaseContext.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess=true,
                Message=MessageInUser.MessageDelete
            };

        }
    }
}
