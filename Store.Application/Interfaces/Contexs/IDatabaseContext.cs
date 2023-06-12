using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Entities.Medias;
using Store.Domain.Entities.Product;
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
        DbSet<Contact> Contacts { get; set; }
         DbSet<ContactType> ContactType { get; set; }
         DbSet<Category> Category { get; set; }
         DbSet<Media> Medias { get; set; }
         DbSet<MediaType> MediaTypes { get; set; }
		 DbSet<Brands> Brands { get; set; }
        DbSet<Comments> Comments { get; set; }
        DbSet<Feature> Features { get; set; }
		 DbSet<ItemTag> ItemTags { get; set; }
		 DbSet<Products> Products { get; set; }
		 DbSet<Rate> Rates { get; set; }
	     DbSet<Tag> Tags { get; set; }
		int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        void Dispose();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
