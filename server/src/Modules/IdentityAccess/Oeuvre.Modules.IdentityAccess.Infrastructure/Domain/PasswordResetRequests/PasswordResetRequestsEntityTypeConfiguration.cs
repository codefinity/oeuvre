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
    public class PasswordResetRequestsEntityTypeConfiguration : IEntityTypeConfiguration<PasswordResetRequest>
    {
        public void Configure(EntityTypeBuilder<PasswordResetRequest> builder)
        {
            builder.ToTable("PasswordResetRequests", "identityaccess");

            builder.HasKey(x => x.Id);

            builder.Property<UserId>("userId").HasColumnName("UserId");

            builder.OwnsOne<PasswordRequestStatus>("status", b =>
            {
                b.Property(x => x.Value).HasColumnName("Status");
            });

            builder.Property<DateTime>("requestedOn").HasColumnName("RequestedOn");

        }

    }
}
