using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.ContentCreation.Domain.Articles
{
    public interface IArticleRepository
    {
        Task AddAsync(Article article);

        Task UpdateAsync(Article article);

        Task<Article> GetByIdAsync(ArticleId article);
    }
}
