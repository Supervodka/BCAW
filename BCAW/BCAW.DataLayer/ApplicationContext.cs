using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
namespace BCAW

{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> FooUsers { get; set; }
        
        public DbSet<Offer> Offers { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-6Q2F7G5;Database=helloappdb;Trusted_Connection=True;");
            }
        }
    }
