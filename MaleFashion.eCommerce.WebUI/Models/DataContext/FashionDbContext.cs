using MaleFashion.eCommerce.WebUI.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Models.DataContext
{
    public class FashionDbContext : DbContext
    {
        public FashionDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<AppInfo> AppInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Aphorism> Aphorisms { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogBanner> BlogBanners { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogDetailsTagsCollection> BlogDetailsTagsCollections { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppInfo>()
                   .Property(ap => ap.CreatedDate)
                   .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");


            builder.Entity<Category>()
                   .Property(ap => ap.CreatedDate)
                   .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");


            builder.Entity<Product>()
                   .Property(ap => ap.CreatedDate)
                   .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");

            builder.Entity<Aphorism>()
                   .Property(ap => ap.CreatedDate)
                   .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");

            builder.Entity<Tag>()
                   .Property(ap => ap.CreatedDate)
                   .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");

            builder.Entity<BlogBanner>()
                 .Property(ap => ap.CreatedDate)
                 .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");

            builder.Entity<Blog>()
                   .Property(ap => ap.CreatedDate)
                   .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");

            builder.Entity<Department>()
                   .Property(ap => ap.CreatedDate)
                   .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");

            builder.Entity<Contact>()
                   .Property(ap => ap.CreatedDate)
                   .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");
        }
    }
}
