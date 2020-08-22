using Domania.Domain;
using Oeuvre.Modules.ContentCreation.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Domain.Articles
{
    public class Article : Entity, IAggregateRoot
    {
        public ArticleId Id { get; private set; }

        private TenantId tenantId;

        private string topic;

        private string body;

        public Article()
        {

        }

        public Article(ArticleId articleId,
                        TenantId tenantId, 
                        string topic, 
                        string body)
        {
            this.Id = new ArticleId(articleId.Value);
            this.tenantId = new TenantId(tenantId.Value);
            this.topic = topic;
            this.body = body;
        }

    }
}
