using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Topic;
using Common.ViewModel.Topic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Authorize(Roles = "w,rw,rwx,wx")]
    public class TopicController : Controller
    {
        private readonly ISiteDbContext _context;
        private readonly ITopicFacad _topicFacad;
        public TopicController(ISiteDbContext context, ITopicFacad topicFacad)
        {
            _context = context;
            _topicFacad = topicFacad;
        }



        // GET: UserController
        public async Task<ActionResult> Index(CancellationToken CT)
        {
            var Result = await _topicFacad.GetAll(null, CT);
            if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                return View(Result.ResultObject);
            return View(Result.Messages[0].Message);
        }
        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id, CancellationToken CT)
        {
            var ReqEditUser = await _topicFacad.Get(id, null, CT);
            if (ReqEditUser.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                ReqEditUser.ResultObject.Parrent = await _topicFacad.Get(ReqEditUser.ResultObject.ParrentID , CT) ?? new TopicVM { Title ="بدون سرشاخه"};
           return View(ReqEditUser.ResultObject);
        }

        // GET: UserController/Create
        public async Task<ActionResult> Create()
        {
            var AllTopic = await _topicFacad.GetAll(null ,new  CancellationToken() );
            ViewBag.Topics = AllTopic.ResultObject;
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TopicVM ReqAdd, CancellationToken CT)
        {
            var Result = await _topicFacad.Add(ReqAdd, CT);
            if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                return RedirectToAction(nameof(Index));

            return View(Result.Messages[0].Message);
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit( long ID, CancellationToken CT)
        {
            var Result = await _topicFacad.Get(ID, null, CT);
            if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
            {
               // var parrent = await _topicFacad.Get(Result.ResultObject.ParrentID, null, CT);
                Result.ResultObject.Parrent = await _topicFacad.Get(Result.ResultObject.ParrentID, CT) ?? new TopicVM { Title = "بدون سرشاخه" };
                var AllTopic =await _topicFacad.GetAll(null, CT);
                ViewBag.Topics = AllTopic.ResultObject;
                return View(Result.ResultObject);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(IFormCollection valuePairs ,  TopicVM ReqEdit, CancellationToken CT)
        {
            var Result = await _topicFacad.Edit(ReqEdit, CT);

            if (Result.Messages.First().ServiceStatus == Common.Messages.ServiceStatus.OK)
                return Redirect(Request.Headers["Referer"].ToString());
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(long ID, CancellationToken CT)
        {
            var Result = await _topicFacad.Get(ID, null, CT);
            if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                return View(Result.ResultObject);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string ID, CancellationToken CT)
        {
            var Result = await _topicFacad.Delete(long.Parse(ID), CT);
            if (Result.Messages.First().ServiceStatus == Common.Messages.ServiceStatus.OK)
                return Redirect(nameof(Index));
            return RedirectToAction(nameof(Index));
        }
    }
}
