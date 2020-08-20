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

        public Article(ArticleId id, 
                        TenantId tenantId, 
                        string topic, 
                        string body)
        {
            this.Id = id;
            this.tenantId = tenantId;
            this.topic = topic;
            this.body = body;
        }

    }
}
