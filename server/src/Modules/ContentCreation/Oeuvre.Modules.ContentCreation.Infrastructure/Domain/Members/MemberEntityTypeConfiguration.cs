using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.ContentCreation.Domain.Members;
using Oeuvre.Modules.ContentCreation.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Domain.Members
{
    internal class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members", "contentcreation");

            builder.HasKey(x => x.Id);

            builder.Property<TenantId>("tenantId").HasColumnName("TenantId");

            builder.Property<string>("eMailId").HasColumnName("EMailId");
            builder.Property<string>("firstName").HasColumnName("FirstName");
            builder.Property<string>("lastName").HasColumnName("LastName");

        }
    }
}
