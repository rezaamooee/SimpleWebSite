using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Post;
using Application.Services.Topic;
using Application.Services.User;
using Common.ViewModel.Post;
using Common.ViewModel.User;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class PostController : Controller
    {
        private readonly ISiteDbContext _context;
        private readonly IPostFacad _PostFacad;
        public PostController(ISiteDbContext context, IPostFacad PostFacad)
        {
            _context = context;
            _PostFacad = PostFacad;
        }

        // GET: PostController
        public async Task<ActionResult> Index(CancellationToken CT)
        {
            var Result = await _PostFacad.GetAll<PostAbsVM>(null, CT);
            if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                return View(Result.ResultObject);
            return View();
        }
        // GET: PostController/Details/5
        public async Task<ActionResult> Details(int id, CancellationToken CT)
        {
            var ReqEditUser = await _PostFacad.Get<PostVM>(id, null, CT);
            if (ReqEditUser.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                return View(ReqEditUser.ResultObject);
            return View();
        }

        // GET: PostController/Create
        public async Task<ActionResult> Create()
        {

            var AllTopic = await new TopicFacad(_context).GetAll(null, new CancellationToken());
            ViewBag.Topics = AllTopic.ResultObject;
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PostAddVM ReqAdd, CancellationToken CT)
        {

            var username = User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var Author = User.Identity.IsAuthenticated ? await new UserFacad(_context).Filter<UserInfoVM>(new Common.ViewModel.User.UserFilterVM() { Username = username , IsActive = true}, CT) : null;
            if (Author != null && Author.ResultObject.Count==1)
            {
                ReqAdd.Author = Author.ResultObject.FirstOrDefault();
                var Result = await _PostFacad.Add(ReqAdd, CT);
                if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                    return RedirectToAction(nameof(Index));
            }
                return View();
        }

        // GET: PostController/Edit/5
        public async Task<ActionResult> Edit(long ID, CancellationToken CT)
        {
            var Result = await _PostFacad.Get<PostVM>(ID, null, CT);

            if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
            {
                var AllTopic = await new TopicFacad(_context).GetAll(null, new CancellationToken());
                ViewBag.Topics = AllTopic.ResultObject;
                return View(Result.ResultObject);
            }
            
            return Redirect(nameof(Index));
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PostVM ReqEdit, CancellationToken CT)
        {
            var username = User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var Author = User.Identity.IsAuthenticated ? await new UserFacad(_context).Filter<UserInfoVM>(new Common.ViewModel.User.UserFilterVM() { Username = username, IsActive = true }, CT) : null;
            if (Author != null && Author.ResultObject.Count == 1)
            {
                ReqEdit.Author = Author.ResultObject.FirstOrDefault();
                var topic =await new TopicFacad(_context).Get(ReqEdit.TopicID, null, CT);
                if (topic != null && topic.ResultObject != null)
                    ReqEdit.Topic = topic.ResultObject;
                else
                    return RedirectToAction(nameof(Index));

                var Result = await _PostFacad.Edit(ReqEdit, CT);
                if (Result.Messages.First().ServiceStatus == Common.Messages.ServiceStatus.OK)
                    return Redirect(Request.Headers["Referer"].ToString());
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PostController/Delete/5
        public async Task<ActionResult> Delete(long ID, CancellationToken CT)
        {
            var Result = await _PostFacad.Get<PostAbsVM>(ID, null, CT);
            if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                return View(Result.ResultObject);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string ID, CancellationToken CT)
        {
            var Result = await _PostFacad.Delete(long.Parse(ID), CT);
            if (Result.Messages.First().ServiceStatus == Common.Messages.ServiceStatus.OK)
                return Redirect(nameof(Index));
            return RedirectToAction(nameof(Index));

        }
    }
}
