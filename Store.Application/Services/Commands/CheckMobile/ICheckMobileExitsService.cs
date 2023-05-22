using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Commands
{
    public interface ICheckMobileExitsService
    {
        Task<List<FindDtailMobileDto>> Execute(string Mobile, long Id);
    }
}
