using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Queries.GetUsers
{
    public class ResultGetUsersDto
    {
        public List<GetUsersDto> Users { get; set; }
        public long Rows;
    }
}
