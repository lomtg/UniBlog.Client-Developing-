using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniBlog.Data.Models;
using UniBlog.Data.Repository;

namespace UniBlog.Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthorsRepository _userManager;

        public AccountController(IAuthorsRepository userManager)
        {
            if (userManager is null)
            {
                throw new ArgumentNullException(nameof(userManager));
            }

            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new Login {ReturnUrl = returnUrl });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if(String.IsNullOrWhiteSpace(login.Username) && String.IsNullOrWhiteSpace(login.Password))
            {
                return View();
            }

            var user = await _userManager.GetAuthorByUsername(login.Username,login.Password);
            if (user == null)
            {
                ViewBag.Error = "Incorrect Credentials";
                return View();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName),
                //new Claim("Username",user.UserName)
                //new Claim(ClaimTypes.Role, user.Role),
        };
                var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = login.RememberLogin });

                return LocalRedirect(login.ReturnUrl);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

    }
}
