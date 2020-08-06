using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.UserRegistrations
{
    internal class UserRegistrationEntityTypeConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable("Registration");

            builder.HasKey(x => x.Id);

            //builder.OwnsOne<UserRegistrationId>("_status", b =>
            //{
            //    b.Property(x => x.Value).HasColumnName("StatusCode");
            //});

            //builder.Property<string>("firstName").HasColumnName("FirstName");
            //builder.Property<string>("lastName").HasColumnName("LastName");

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

            //builder.Property<string>("mobileNumber").HasColumnName("MobileNo");


            builder.Property<string>("eMailId").HasColumnName("EMail");
            builder.Property<string>("password").HasColumnName("Password");
            builder.Property<DateTime>("registrationDate").HasColumnName("RegistrationDate");
            builder.Property<DateTime?>("confirmedDate").HasColumnName("ConfirmedDate");

            builder.OwnsOne<UserRegistrationStatus>("status", b =>
                {
                    b.Property(x => x.Value).HasColumnName("StatusCode");
                });
        }
    }
}
