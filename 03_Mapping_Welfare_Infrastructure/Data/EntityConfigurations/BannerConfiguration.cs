using System;
using System.Collections.Generic;
using System.Text;
using _02_Mapping_Welfare_Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _03_Mapping_Welfare_Infrastructure.Data.EntityConfigurations
{
    class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            throw new NotImplementedException();
        }
    }
}
