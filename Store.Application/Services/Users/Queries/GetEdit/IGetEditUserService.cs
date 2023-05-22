using Store.Application.Services.Users.Command.RegisterUser;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Queries.Edit
{
    public interface IGetEditUserService
    {
        Task<EditUserDto> Execute(long Id);

    }

}
