using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.ContentCreation.Domain.Articles;
using Oeuvre.Modules.ContentCreation.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Domain.Articles
{
    public class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<Article>
    {

        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles", "contentcreation");

            builder.HasKey(x => x.Id);

            builder.Property<TenantId>("tenantId").HasColumnName("TenantId");

            builder.Property<string>("topic").HasColumnName("Topic");
            builder.Property<string>("body").HasColumnName("Body");


        }

    }
}
