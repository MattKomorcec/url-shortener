using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Link>()
                .HasData(
                    new Link
                    {
                        Id = Guid.NewGuid(),
                        FullUrl = "http://www.google.com",
                        ShortUrl = "/1",
                        IsPublic = true
                    },
                    new Link
                    {
                        Id = Guid.NewGuid(),
                        FullUrl = "http://www.facebook.com",
                        ShortUrl = "/2",
                        IsPublic = true
                    },
                    new Link
                    {
                        Id = Guid.NewGuid(),
                        FullUrl = "http://www.microsoft.com",
                        ShortUrl = "/3",
                        IsPublic = false
                    }
                );
        }
    }
}
