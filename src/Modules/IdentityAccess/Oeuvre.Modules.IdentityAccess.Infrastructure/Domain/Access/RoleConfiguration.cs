using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.IdentityAccess.Domain.Access;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Access
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {

        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.Property<string>("name").HasColumnName("name");
            builder.Property<string>("code").HasColumnName("code");

        }

    }
}
