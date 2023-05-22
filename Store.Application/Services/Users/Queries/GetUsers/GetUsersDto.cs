﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersDto
    {
        public long Id { get; set; }
        public string? FullName { get; set; }
        public bool? Gender { get; set; }
        public bool IsActived { get; set; }
        public List<ContactDto> Contacts { get; set; }
    }
}
