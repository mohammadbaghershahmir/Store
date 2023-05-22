using Store.Application.Services.Users.Queries.Edit;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.EditUser
{
    public interface IEditUserService
    {
        Task<ResultDto> Execute(EditUserDto EditUserService);
    }
}
