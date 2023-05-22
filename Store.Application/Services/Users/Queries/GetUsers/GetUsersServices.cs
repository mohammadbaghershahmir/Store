using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersServices : IGetUsersServices
    {
        private readonly IDatabaseContext _databaseContext;
        public GetUsersServices(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<ResultGetUsersDto> Execute(RequestGetUsersDto request)
        {
            var users = _databaseContext.Users.Include(y=>y.Contacts).ThenInclude(c=>c.ContactType).AsQueryable();
         
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) || p.LastName.Contains(request.SearchKey));
                
               
            }
            var contact =await _databaseContext.Contacts.Where(r=>r.UserId==r.Id).ToListAsync();
            int RowsCount = 0;
            var userslistt = users.ToPaged(request.Page, 20, out RowsCount).Select(p => new GetUsersDto

            {
                FullName = p.FullName,
                Id = p.Id,
                IsActived = p.IsActive,
                Contacts =p.Contacts.Select(r => new ContactDto()
                       {

                           IconContact = r.ContactType.Icon,
                           ContactValue = r.Value
                       }).ToList(),
               

            }

            ).ToList();
            return new ResultGetUsersDto
            {
                Rows = RowsCount,
                Users = userslistt,

            };
        }
    }
}
