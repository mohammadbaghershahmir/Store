using Store.Application.Services.Users.Command.RegisterUser;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.Site.SignUpUser
{
    public interface ISignUpUserService
    {
       Task<ResultDto<ResultRegisterUserDto>> Execute(RequestSignUpUserDto Request);
    }
}
