using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Domain;

namespace Voter.EfDataAccess.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasMany(r => r.Persons).WithOne(p => p.Region)
                .HasForeignKey(p => p.RegionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
