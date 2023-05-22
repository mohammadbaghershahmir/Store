
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDatabaseContext _context;

        public GetRolesService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<RolesDto>> Execute()
        {
            var roles = _context.Roles.Select(p => new RolesDto
            {
                Id = p.Id,
                NameRole = p.NameRole,
                Description = p.Description,
                Title = p.Title,

            }).ToList();
            return new ResultDto<List<RolesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = "",
            };
        }
    }
}
