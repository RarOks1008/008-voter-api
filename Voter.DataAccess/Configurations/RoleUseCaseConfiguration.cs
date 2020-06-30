using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Domain;

namespace Voter.EfDataAccess.Configurations
{
    public class RoleUseCaseConfiguration : IEntityTypeConfiguration<RoleUseCase>
    {
        public void Configure(EntityTypeBuilder<RoleUseCase> builder)
        {
            builder.Property(x => x.UseCaseId).IsRequired();
        }
    }
}
