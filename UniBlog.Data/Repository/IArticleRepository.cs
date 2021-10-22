using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniBlog.Data.Models;
using UniBlog.Data.ViewModels;

namespace UniBlog.Data.Repository
{
    public interface IArticleRepository
    {
        public Task AddArticle(Article article);
        public Task<IEnumerable<ArticleViewModel>> GetArticles();

    }
}
