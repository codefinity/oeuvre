using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.IdentityAccess.Domain.Tenants;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.UserRegistrations
{
    internal class UserRegistrationEntityTypeConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable("Registrations","identityaccess");

            builder.HasKey(x => x.Id);

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
            builder.Property<DateTime>("registrationDate").HasColumnName("RegistrationDate");
            builder.Property<DateTime?>("confirmedDate").HasColumnName("ConfirmedDate");

            builder.OwnsOne<UserRegistrationStatus>("status", b =>
                {
                    b.Property(x => x.Value).HasColumnName("StatusCode");
                });

            builder.Property<bool>("termsAndConditionsAccepted").HasColumnName("TermsAndConditionsAccepted");
        }
    }
}
