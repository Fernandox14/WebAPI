using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Provider> Provider { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
