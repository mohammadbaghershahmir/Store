using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.DeleteUser
{
    public interface IRemoveService
    {
       Task<ResultDto> Execute(long id);
    }
}
