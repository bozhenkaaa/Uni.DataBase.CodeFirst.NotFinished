using System;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.models
{

    public class WebApplication4Context:DbContext
    {
        public virtual DbSet <Clothes> Clothess { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public WebApplication4Context (DbContextOptions <WebApplication4Context> options):base (options)
        {
            Database.EnsureCreated();
        }


    }
}