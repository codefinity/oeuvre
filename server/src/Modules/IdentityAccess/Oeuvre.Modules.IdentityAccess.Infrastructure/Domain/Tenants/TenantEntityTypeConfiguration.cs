using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.IdentityAccess.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Tenants
{
    public class TenantEntityTypeConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {

            builder.ToTable("Tenants", "identityaccess");

            builder.HasKey(x => x.Id);

            builder.Property<string>("name").HasColumnName("Name");

            builder.Property<bool>("isActive").HasColumnName("IsActive");

        }

    }
}
