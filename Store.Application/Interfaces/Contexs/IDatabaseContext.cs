using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.Contexs
{
    public interface IDatabaseContext
    {
        DbSet<User> Users { get; set; }
         DbSet<Role> Roles { get; set; }
         DbSet<UserInRole> UserInRoles { get; set; }
         DbSet<Login> Logins { get; set; }
         DbSet<Contact> Contacts { get; set; }
         DbSet<ContactType> ContactTypes { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        void Dispose();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,CancellationToken cancellationToken=new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken());
    }
}
