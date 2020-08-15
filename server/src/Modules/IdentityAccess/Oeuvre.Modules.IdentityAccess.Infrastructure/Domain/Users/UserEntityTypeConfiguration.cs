using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.IdentityAccess.Domain.Tenants;
using Oeuvre.Modules.IdentityAccess.Domain.Users;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Users
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("Users", "identityaccess");

            builder.HasKey(x => x.Id);

            //builder.Property(e => e.Id)
            //        .HasColumnName("Id")
            //        .ValueGeneratedNever();

            builder.Property<TenantId>("tenantId").HasColumnName("TenantId");

            builder.OwnsOne<FullName>("fullName", a =>
            {
                a.Property(x => x.FirstName).HasColumnName("FirstName");
                a.Property(x => x.LastName).HasColumnName("LastName");
            });

            builder.OwnsOne<MobileNumber>("mobileNumber", a =>
            {
                a.Property(x => x.CountryCode).HasColumnName("CountryCode");
                a.Property(x => x.MobileNo).HasColumnName("MobileNo");
            });

            builder.Property<string>("eMailId").HasColumnName("EMail");
            builder.Property<string>("password").HasColumnName("Password");
            builder.Property<bool>("isActive").HasColumnName("IsActive");

            builder.OwnsMany<UserRole>("roles", b =>
            {
                b.WithOwner().HasForeignKey("UserId");
                b.ToTable("UserRoles", "identityaccess");
                b.Property<UserId>("UserId");
                b.Property<string>("Value").HasColumnName("RoleCode");
                b.HasKey("UserId", "Value");
            });
        }
    }
}
