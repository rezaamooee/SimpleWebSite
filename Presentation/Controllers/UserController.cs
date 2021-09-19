using Application.Interfaces.Contexts;
using Application.Interfaces.Services.User;
using Application.Services.Role;
using Common.ViewModel.User;
using Entity.DBEntities;
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
    public class UserController : Controller
    {
        private readonly ISiteDbContext _context;
        private readonly IUserFacad _userFacad;
        public UserController(ISiteDbContext context, IUserFacad userFacad)
        {
            _context = context;
            _userFacad = userFacad;
        }



        // GET: UserController
        public async Task<ActionResult> Index(CancellationToken CT)
        {
            var Result = await _userFacad.GetAll<UserAbsVM>(null,CT);
            if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                return View(Result.ResultObject);
            return View(Result.Messages[0].Message);
        }
        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int ID, CancellationToken CT)
        {
            var ReqEditUser = await _userFacad.Get<UserInfoVM>(ID, null,CT);
            if (ReqEditUser.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                return View(ReqEditUser.ResultObject);
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create(CancellationToken CT)
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserVM ReqAdd,CancellationToken CT)
        {
            var Result = await _userFacad.Add(ReqAdd, CT);
            if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                return RedirectToAction(nameof(Index));
            
            return View(Result.Messages[0].Message);
        }

        // GET: UserController/Edit/5
        public async Task< ActionResult> Edit(long ID,CancellationToken CT)
        {
            var Result =await _userFacad.Get<UserVM>(ID, null,CT);
            if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
            {
                var Roles = await new RoleFacad(_context).GetAll(null, CT);
                ViewBag.Roles = Roles.ResultObject;
                Result.ResultObject.Password = "";
                return View(Result.ResultObject);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserVM ReqEdit ,CancellationToken CT)
        {
            var Result =await  _userFacad.Edit(ReqEdit, CT);
            if (Result.Messages.First().ServiceStatus == Common.Messages.ServiceStatus.OK)
                return Redirect(Request.Headers["Referer"].ToString());
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(long ID, CancellationToken CT)
        {
            var Result = await _userFacad.Get<UserInfoVM>(ID, null, CT);
            if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                return View(Result.ResultObject);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Delete(string ID, CancellationToken CT) 
        {
            var Result = await _userFacad.Delete(long.Parse(ID), CT);
            if (Result.Messages.First().ServiceStatus == Common.Messages.ServiceStatus.OK)
                return Redirect(nameof(Index));
            return RedirectToAction(nameof(Index));
        }
    }
}
