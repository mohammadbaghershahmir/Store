using Store.Application.Services.Commands.CheckUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Commands.CheckEmail
{
    public interface ICheckEmailService
    {
       Task<List<FindDtailEmailDto>> Execute(string email, long id);
    }
}
