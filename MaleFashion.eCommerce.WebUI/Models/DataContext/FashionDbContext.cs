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
        public DbSet<AboutUsBanner> AboutUsBanners { get; set; }
        public DbSet<TeamJob> TeamJobs { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<HappyClient> HappyClients { get; set; }
        public DbSet<WhyWe> WhyWes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // If we want to add new schema to our database, so we can use this code...
            //builder.HasDefaultSchema("FSHN");

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

            builder.Entity<AboutUsBanner>()
              .Property(ap => ap.CreatedDate)
              .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");

            builder.Entity<TeamJob>()
              .Property(ap => ap.CreatedDate)
              .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");

            builder.Entity<Team>()
              .Property(ap => ap.CreatedDate)
              .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");

            builder.Entity<HappyClient>()
              .Property(ap => ap.CreatedDate)
              .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");

            builder.Entity<WhyWe>()
           .Property(ap => ap.CreatedDate)
           .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())");
        }
    }
}
