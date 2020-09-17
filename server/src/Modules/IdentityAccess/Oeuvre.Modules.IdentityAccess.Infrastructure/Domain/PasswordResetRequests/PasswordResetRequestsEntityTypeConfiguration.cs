using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using Oeuvre.Modules.IdentityAccess.Domain.Tenants;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Tenants
{
    public class PasswordResetRequestsEntityTypeConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("PasswordRequests", "identityaccess");

            builder.HasKey(x => x.Id);

            builder.Property<UserId>("userId").HasColumnName("UserId");

            builder.OwnsOne<PasswordRequestStatus>("status", b =>
            {
                b.Property(x => x.Value).HasColumnName("StatusCode");
            });

            builder.Property<string>("requestedOn").HasColumnName("RequestedOn");

        }

    }
}
