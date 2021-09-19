using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Role;
using Application.Services.Role.Command;
using Application.Services.Role.Query;
using Common.Messages;
using Common.ViewModel.Role;
using Entity.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Role
{
    public class RoleFacad :IRoleFacad
    {
        private readonly ISiteDbContext _Context;
        public RoleFacad (ISiteDbContext context )
        {
            _Context = context;
        }

        public async Task<RespMsg<RoleVM>> Add(RoleVM ReqAdd, CancellationToken CT) =>await new RoleCMDServices(_Context).Add(ReqAdd,CT) ;
        public async Task<RespMsg<RoleVM>> Edit(RoleVM ReqEdit, CancellationToken CT) => await new RoleCMDServices(_Context).Edit(ReqEdit, CT);
        public async Task<RespMsg<RoleVM>> Delete(long ReqDelID, CancellationToken CT) => await new RoleCMDServices(_Context).Delete(ReqDelID, CT);
        public async Task<bool> IfExist(long ReqID, bool? IsActive, CancellationToken CT) => await new RoleQUERYServices(_Context).IfExist(ReqID, IsActive, CT);
        public async Task<bool> IfExist(RoleVM ReqVM, bool? IsActive, CancellationToken CT) => await new RoleQUERYServices(_Context).IfExist(ReqVM, IsActive, CT);
        public async Task<RespMsg<RoleVM>> Get(long ReqID, bool? IsActive, CancellationToken CT) => await new RoleQUERYServices(_Context).Get(ReqID, IsActive, CT);
        public async Task<RespMsg<RoleVM>> Get(Permision ReqPermision, bool? IsActive, CancellationToken CT) => await new RoleQUERYServices(_Context).Get(ReqPermision, IsActive, CT);
        public async Task<RespMsg_List<RoleVM>> Filter(RoleFilterVM ReqFilter, CancellationToken CT) => await new RoleQUERYServices(_Context).Filter(ReqFilter,  CT);
        public async Task<RespMsg_List<RoleVM>> GetAll(bool? IsActive, CancellationToken CT) => await new RoleQUERYServices(_Context).GetAll( IsActive, CT);
    }
}
