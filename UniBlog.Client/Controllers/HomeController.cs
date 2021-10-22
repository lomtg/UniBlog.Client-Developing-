﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UniBlog.Data.Models;
using UniBlog.Data.Repository;
using UniBlog.Data.InputModels;
using AutoMapper;

namespace UniBlog.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleRepository _context;
        private readonly IAuthorsRepository _authorsContext;
        private readonly IMapper _mapper;

        public HomeController(IArticleRepository context,
            IAuthorsRepository authorsContext
            ,IMapper mapper)
        {
            _context = context;
            _authorsContext = authorsContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetArticles());
        }
     
        [HttpPost]
        public async Task<IActionResult> Index([FromForm] ArticleInputModel article)
        {
            if (!ModelState.IsValid)
            {
                return View(await _context.GetArticles());
            }

            var mappedArticle = _mapper.Map<Article>(article);
            mappedArticle.AuthorId = await _authorsContext.GetAuthorsId("lomtg");

            await _context.AddArticle(mappedArticle);
            return View(await _context.GetArticles());
        }
    }
}
