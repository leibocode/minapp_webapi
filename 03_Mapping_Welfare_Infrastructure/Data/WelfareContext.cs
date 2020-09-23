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
            modelBuilder.Entity<WechatUser>().HasKey(x=>x.OpenId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Banner> Banners { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Comments> Comments { get; set; }

        public DbSet<WechatUser> WechatUsers { get; set; }
    }
}
