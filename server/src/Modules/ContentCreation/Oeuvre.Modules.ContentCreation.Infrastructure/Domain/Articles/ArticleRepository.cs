using Microsoft.EntityFrameworkCore;
using Oeuvre.Modules.ContentCreation.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Domain.Articles
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ContentCreationContext contentCreationContext;

        public ArticleRepository(ContentCreationContext contentCreationContext)
        {
            this.contentCreationContext = contentCreationContext;
        }

        public async Task AddAsync(Article article)
        {
            //string state = identityAccessContext.Entry(user).State.ToString();

            await contentCreationContext.Article.AddAsync(article);

            try
            {
                //string state1 = identityAccessContext.Entry(user).State.ToString();
                //identityAccessContext.Entry(user).State = EntityState.Modified;
                string state2 = contentCreationContext.Entry(article).State.ToString();

                contentCreationContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task UpdateAsync(Article article)
        {
            await contentCreationContext.Article.AddAsync(article);

            try
            {
                contentCreationContext.Entry(article).State = EntityState.Modified;

                //identityAccessContext.Entry(user);
                //identityAccessContext.

                contentCreationContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task<Article> GetByIdAsync(ArticleId articleId)
        {

            return await contentCreationContext.Article.FirstOrDefaultAsync(x => x.Id == articleId);

        }
    }
}
