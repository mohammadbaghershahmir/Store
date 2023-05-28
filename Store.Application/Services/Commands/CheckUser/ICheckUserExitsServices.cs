using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Commands.CheckUser
{
    public interface ICheckUserExitsService
    {
       Task<bool> Execute(string UserName);
    }
}
