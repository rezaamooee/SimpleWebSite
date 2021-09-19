using Application.Interfaces.Contexts;
using Application.Interfaces.Services.User;
using Common.ViewModel.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Presentation.LocalLogic.Login;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISiteDbContext _context;
        private readonly IUserFacad _userFacad;

        public AccountController(ISiteDbContext context, IUserFacad userService)
        {
            this._context = context;
            this._userFacad = userService;
        }


        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLogin, string ReturnUrl, CancellationToken CT)
        {
            var tryToLogin = await new AuthenticateService(_userFacad).DoLogin(userLogin, CT);
            if (tryToLogin.IsReadyToLogin)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, tryToLogin.Principal, tryToLogin.AuthenticationProperties);
                if (User.Identity.IsAuthenticated)
                {
                    //Make Response Pack For SEO
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.Accepted;
                }
                if (!String.IsNullOrEmpty(ReturnUrl) && !String.IsNullOrWhiteSpace(ReturnUrl))
                    return Redirect(ReturnUrl);
                else
                    return RedirectToAction("Index", "Home");

            }
            return View();
        }
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
