using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Domain.Articles
{
    public class ArticleId : TypedIdValueBase
    {
        public ArticleId(Guid value) : base(value)
        {
        }
    }
}
