using Common.Messages;
using Common.ViewModel.Role;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Role.Command
{
    public interface IRoleCMDServices
    {
        public Task<RespMsg<RoleVM>> Add(RoleVM ReqAdd, CancellationToken CT);
        public  Task<RespMsg<RoleVM>> Edit(RoleVM ReqEdit, CancellationToken CT);
        public Task<RespMsg<RoleVM>> Delete(long ReqDelID, CancellationToken CT);
    }
}
