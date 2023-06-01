using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.Site.LogOutUser
{
    public interface IlogOutUser
    {
        Task<bool> Execute();
    }
}
