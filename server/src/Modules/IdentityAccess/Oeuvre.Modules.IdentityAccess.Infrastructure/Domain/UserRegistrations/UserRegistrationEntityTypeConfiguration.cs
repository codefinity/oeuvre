using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.UserRegistrations
{
    internal class UserRegistrationEntityTypeConfiguration : IEntityTypeConfiguration<UserRegistration>
    {
        public void Configure(EntityTypeBuilder<UserRegistration> builder)
        {
            builder.ToTable("UserRegistrations");

            builder.HasKey(x => x.Id);

            //builder.OwnsOne<UserRegistrationId>("_status", b =>
            //{
            //    b.Property(x => x.Value).HasColumnName("StatusCode");
            //});

            builder.Property<string>("login").HasColumnName("Login");
            builder.Property<string>("email").HasColumnName("Email");
            builder.Property<string>("password").HasColumnName("Password");
            builder.Property<string>("firstName").HasColumnName("FirstName");
            builder.Property<string>("lastName").HasColumnName("LastName");
            builder.Property<string>("name").HasColumnName("Name");
            builder.Property<DateTime>("registerDate").HasColumnName("RegisterDate");
            builder.Property<DateTime?>("confirmedDate").HasColumnName("ConfirmedDate");

            builder.OwnsOne<UserRegistrationStatus>("status", b =>
                {
                    b.Property(x => x.Value).HasColumnName("StatusCode");
                });
        }
    }
}
