using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Domain;

namespace Voter.EfDataAccess.Configurations
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Info).IsRequired();
            builder.HasMany(o => o.Persons).WithOne(p => p.Option)
                .HasForeignKey(p => p.OptionId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
