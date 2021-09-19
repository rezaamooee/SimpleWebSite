using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Post;
using Application.Interfaces.Services.User;
using Common.ViewModel.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISiteDbContext _context;
        private readonly IPostFacad _postFacad;

        public HomeController(ISiteDbContext context, IPostFacad postFacad)
        {
            _context = context;
            _postFacad = postFacad;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

       
        public async Task<IActionResult> Index(CancellationToken CT)
        {
            var Posts = await _postFacad.GetAll<PostAbsVM>(true, CT);
            if (Posts.ResultObject.Count > 0)
                return View(Posts.ResultObject);
            return View();
        }
        [Authorize]

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
