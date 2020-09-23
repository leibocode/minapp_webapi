using _02_Mapping_Welfare_Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Mapping_Welfare_Infrastructure.Data
{
    public class WelfareContext:DbContext
    {
        public WelfareContext(DbContextOptions<WelfareContext> options):base(options)
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Banner> Banners { get; set; }


    }
}
