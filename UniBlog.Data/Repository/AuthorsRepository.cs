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

        public async Task<Author> GetAuthorByUsername(string username,string password)
        {
            var user = await _context.Authors.FirstOrDefaultAsync(x => x.UserName == username
            && x.Password == password);
            return user;
        }
    }
}
