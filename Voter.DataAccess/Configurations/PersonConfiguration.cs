using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Domain;

namespace Voter.EfDataAccess.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.PersonalId).IsRequired();
            builder.HasIndex(x => x.PersonalId).IsUnique();
            builder.Property(x => x.Password).IsRequired();
        }
    }
}
