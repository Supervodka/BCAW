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
                optionsBuilder.UseSqlServer(@"Server=WS-779;Database=helloappdb;Trusted_Connection=True;");
            //WS-779 workmachine server
            //DESKTOP-6Q2F7G5 home

        }
    }
    }
