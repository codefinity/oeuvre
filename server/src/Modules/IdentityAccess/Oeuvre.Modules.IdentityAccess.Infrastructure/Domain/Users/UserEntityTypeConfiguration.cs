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

            //CREATE TABLE public."User"
            //(
            //    --"Id" uuid PRIMARY KEY,
            //    --"TenantId" uuid NOT NULL,
            //    --"FirstName" VARCHAR(50) NOT NULL,
            //    --"LastName" VARCHAR(50) NOT NULL,
            //    --"CountryCode" Varchar(50) NOT NULL,
            //    --"MobileNo" VARCHAR(50) NOT NULL,
            //    --"EMail" VARCHAR(255) NOT NULL,
            //    --"Password" VARCHAR(255) NOT NULL,
            //    --"isActive" BOOLEAN NOT NULL 
            //);

            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property<TenantId>("tenantId").HasColumnName("TenantId");

            builder.OwnsOne<FullName>("fullName", a =>
            {
                a.Property("firstName").HasColumnName("FirstName");
                a.Property("lastName").HasColumnName("LastName");
            });

            builder.OwnsOne<MobileNumber>("mobileNumber", a =>
            {
                a.Property("countryCode").HasColumnName("CountryCode");
                a.Property("mobileNumber").HasColumnName("MobileNo");
            });

            builder.Property<string>("eMailId").HasColumnName("EMail");
            builder.Property<string>("password").HasColumnName("Password");
            builder.Property<bool>("isActive").HasColumnName("IsActive");

            //builder.OwnsMany<UserRole>("_roles", b =>
            //{
            //    b.WithOwner().HasForeignKey("UserId");
            //    b.ToTable("UserRoles", "users");
            //    b.Property<UserId>("UserId");
            //    b.Property<string>("Value").HasColumnName("RoleCode");
            //    b.HasKey("UserId", "Value");
            //});
        }
    }
}
