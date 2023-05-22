using Store.Application.Services.Users.Queries.GetUsers;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.RegisterUser
{
    public interface IRegisterUserService
    {


       Task<ResultDto<ResultRegisterUserDto>> Execute(RequestRegisterUserDto request);
    }
}
