using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniBlog.Data.Models;

namespace UniBlog.Data.Repository
{
    public interface IAuthorsRepository 
    {
        public Task RegisterAuthor(Author author);
        public Task<Guid> GetAuthorsId(string Username);
        public Task<String> GetAuthorsUsername(Guid Id);
    }
}
