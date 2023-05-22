using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Commands.CheckEmail
{
    public class FindDtailEmailDto
    {
        public long IdUser { get; set; }
        public string Email { get; set; }
        
    }
}
