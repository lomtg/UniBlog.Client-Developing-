using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBlog.Data.Models;
using UniBlog.Data.ViewModels;

namespace UniBlog.Data.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticlesDbContext _context;
        private readonly IMapper _mapper;

        public ArticleRepository(ArticlesDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddArticle(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ArticleViewModel>> GetArticles()
        {
            var articlesFromRepo = await _context.Articles.ToListAsync();
            var articlesDto = new List<ArticleViewModel>();
            
            foreach(var article in articlesFromRepo)
            {
                articlesDto.Add(new ArticleViewModel()
                {
                    Username = article.AuthorUsername,
                    Title = article.Title,
                    Description = article.Description
                });
            }
            return articlesDto;
        }

        /*public async Task<String> GetAuthorsUsername(Guid Id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == Id);
            return author.UserName;
        } */

        public async Task<IEnumerable<Article>> GetArticlesByAuthor(Guid id)
        {
            return await _context.Articles.Where(x => x.Id == id).ToListAsync();
        }
    }
}
