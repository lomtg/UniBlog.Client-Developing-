using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBlog.Data.Models;

namespace UniBlog.Data.Repository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly ArticlesDbContext _context;

        public AuthorsRepository(ArticlesDbContext context)
        {
            _context = context;
        }

        public async Task RegisterAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        /*public async Task<Guid> GetAuthorsId(string Username)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.UserName == Username);
            return author.Id;
        }*/
        /*public async Task<String> GetAuthorsUsername(Guid Id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == Id);
            return author.UserName;
        }*/
    }
}
