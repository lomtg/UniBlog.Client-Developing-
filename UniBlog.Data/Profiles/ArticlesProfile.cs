using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UniBlog.Data.InputModels;
using UniBlog.Data.Models;
using UniBlog.Data.Repository;
using UniBlog.Data.ViewModels;

namespace UniBlog.Data.Profiles
{
    class ArticlesProfile : Profile
    {
 
        public ArticlesProfile()
        {
            CreateMap<ArticleInputModel, Article>();
            CreateMap<Article, ArticleViewModel>();
        }
    }
}
