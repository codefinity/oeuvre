using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.IdentityAccess.Domain.Access;
using Oeuvre.Modules.IdentityAccess.Domain.Identity;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Access
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {

        public void Configure(EntityTypeBuilder<Permission> builder)
        {

            builder.Property<string>("accessCode").HasColumnName("accessCode");
            builder.Property<string>("accessName").HasColumnName("accessName");

            builder.OwnsMany<PermissionRole>("permissionroles", b =>
            {
                b.ToTable("PermissionRoles");
                b.WithOwner().HasForeignKey("PermissionId");
                b.Property<string>(r => r.Code);
                b.HasKey("PermissionId", "Code");


                //b.ToTable("Roles", "users");
                //b.Property<UserId>("UserId");
                //b.Property<string>("Name").HasColumnName("Name");
                //b.WithOwner().HasForeignKey("UserId");
                //b.HasKey("UserId", "Name");

            });

        }
    }
}
