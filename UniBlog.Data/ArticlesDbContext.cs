using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniBlog.Data.Models;

namespace UniBlog.Data
{
    public class ArticlesDbContext : DbContext
    {
        public ArticlesDbContext(DbContextOptions<ArticlesDbContext> options)
        : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        
    }
}
