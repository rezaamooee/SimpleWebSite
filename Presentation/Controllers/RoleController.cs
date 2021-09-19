using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Role;
using Common.ViewModel.Role;
using Entity.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Authorize(Roles = "w,rw,rwx,wx")]
    public class RoleController : Controller
    {
        private readonly ISiteDbContext _context;
        private readonly IRoleFacad _roleFacad;
        public RoleController(ISiteDbContext context, IRoleFacad roleFacad)
        {
            _context = context;
            _roleFacad = roleFacad;
        }



        // GET: UserController
        public async Task<ActionResult> Index(CancellationToken CT)
        {
            var Result = await _roleFacad.GetAll(null, CT);
            if (Result.ResultObject != null) 
                if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                return View(Result.ResultObject);
            return View(Result.Messages[0].Message);
        }
        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id, CancellationToken CT)
        {
            var Result = await _roleFacad.Get(id, null, CT);
            if (Result.ResultObject != null) 
                if (Result.Messages[0].ServiceStatus == Common.Messages.ServiceStatus.OK)
                return View(Result.ResultObject);
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleVM AddRoleVmForm, CancellationToken CT)
        {
            var Result = await _roleFacad.Add(AddRoleVmForm, CT);
            if (Result.ResultObject != null)
                if (Result.Messages.First().ServiceStatus == Common.Messages.ServiceStatus.OK)
                    return RedirectToAction(nameof(Index));

            return View(Result.Messages[0].Message);
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(long id, CancellationToken CT)
        {
            var Result = await _roleFacad.Get(id, null, CT);
            if (Result.ResultObject != null)
                if (Result.Messages.First().ServiceStatus == Common.Messages.ServiceStatus.OK)
                    return View(Result.ResultObject);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RoleVM ReqEdit, CancellationToken CT)
        {
            var Result = await _roleFacad.Edit(ReqEdit, CT);
            if (Result.ResultObject != null)
                if (Result.Messages.First().ServiceStatus == Common.Messages.ServiceStatus.OK)
                    return Redirect(Request.Headers["Referer"].ToString());
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(long id, CancellationToken CT)
        {
            var Result = await _roleFacad.Get(id, null, CT);
            if (Result.ResultObject != null)
                if (Result.Messages.First().ServiceStatus == Common.Messages.ServiceStatus.OK)
                    return View(Result.ResultObject);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, CancellationToken CT)
        {
            var Result = await _roleFacad.Delete(long.Parse(id), CT);
            if (Result.ResultObject != null)
                if (Result.Messages.First().ServiceStatus == Common.Messages.ServiceStatus.OK)
                    return Redirect(nameof(Index));
            return RedirectToAction(nameof(Index));
        }
    }
}
