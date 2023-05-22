using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Constant.Roles;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Contexs
{
    public class DatabaseContex:DbContext,IDatabaseContext
    {
        
        public DatabaseContex(DbContextOptions options) : base(options) 
        {
        
        
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole>UserInRoles { get; set; }
        public DbSet<Login>Logins { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public  DbSet<ContactType> ContactTypes { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(a => a.RowVersion).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Role>().Property(a => a.RowVersion).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<UserInRole>().Property(a => a.RowVersion).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Login>().Property(a => a.RowVersion).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Contact>().Property(a => a.RowVersion).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<ContactType>().Property(a => a.RowVersion).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();


            //Insert Data To ContactType
            modelBuilder.Entity<ContactType>().HasData(new ContactType { Id = 1, Title = ContactsTypeTitle.Mobail, Value = ContactsTypeValue.Mobail });
            modelBuilder.Entity<ContactType>().HasData(new ContactType { Id = 2, Title = ContactsTypeTitle.Phone, Value = ContactsTypeValue.Phone });
            modelBuilder.Entity<ContactType>().HasData(new ContactType { Id = 3, Title = ContactsTypeTitle.Email, Value = ContactsTypeValue.Email });
            modelBuilder.Entity<ContactType>().HasData(new ContactType { Id = 4, Title = ContactsTypeTitle.Address, Value = ContactsTypeValue.Address });
            //End ContactType
            //Insert Data To Role
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, NameRole = UserRoles.Admin, Title = UserRoleTitle.Admin });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, NameRole = UserRoles.Operator, Title = UserRoleTitle.Operator });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, NameRole = UserRoles.Customer, Title = UserRoleTitle.Customer });
            //End Role
            //Filter Is Removed
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
        }
    }
}
