using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.ContentCreation.Domain.Collaborators;
using Oeuvre.Modules.ContentCreation.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Domain.Collaborators
{
    public class CollaboratorEntityTypeConfiguration : IEntityTypeConfiguration<Collaborator>
    {

        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.ToTable("Collaborators", "contentcreation");

            builder.HasKey(x => x.Id);

            builder.Property<TenantId>("tenantId").HasColumnName("TenantId");

            builder.Property<string>("name").HasColumnName("Name");
            builder.Property<string>("email").HasColumnName("Email");

            builder.Property<DateTime>("createdDate").HasColumnName("CreatedDate");

        }

    }
}
