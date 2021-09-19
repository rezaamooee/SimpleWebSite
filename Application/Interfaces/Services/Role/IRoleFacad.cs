using Common.Messages;
using Common.ViewModel.Role;
using Common.ViewModel.User;
using Entity.DBEntities;
using Entity.Tools;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Role
{
    public interface IRoleFacad
    {
        public Task<RespMsg<RoleVM>> Add(RoleVM ReqAdd, CancellationToken CT);
        public Task<RespMsg<RoleVM>> Edit(RoleVM ReqEdit, CancellationToken CT);
        public Task<RespMsg<RoleVM>> Delete(long ReqDelID, CancellationToken CT);
        public Task<bool> IfExist(long ReqID, bool? IsActive, CancellationToken CT);
        public Task<bool> IfExist(RoleVM ReqVM, bool? IsActive, CancellationToken CT);
        public Task<RespMsg<RoleVM>> Get(long ReqID, bool? IsActive, CancellationToken CT);
        public Task<RespMsg<RoleVM>> Get(Permision ReqPermision, bool? IsActive, CancellationToken CT);
        public Task<RespMsg_List<RoleVM>> Filter(RoleFilterVM ReqFilter, CancellationToken CT);
        public Task<RespMsg_List<RoleVM>> GetAll(bool? IsActive, CancellationToken CT);


    }
}