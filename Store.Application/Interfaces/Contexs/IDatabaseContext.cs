using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Entities.Carts;
using Store.Domain.Entities.Finances;
using Store.Domain.Entities.Medias;
using Store.Domain.Entities.Orders;
using Store.Domain.Entities.Post;
using Store.Domain.Entities.Products;
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
        DbSet<Brand> Brands { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<ItemTag> ItemTags { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Rate> Rates { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<Province> Provinces { get; set; }
        DbSet<UserAddress> UserAddresses { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<RequestPay> RequestPays { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        void Dispose();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
