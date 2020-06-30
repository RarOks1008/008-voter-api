using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Domain;

namespace Voter.EfDataAccess.Configurations
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(s => s.Options).WithOne(o => o.State)
                .HasForeignKey(o => o.StateId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.Regions).WithOne(r => r.State)
                .HasForeignKey(r => r.StateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
