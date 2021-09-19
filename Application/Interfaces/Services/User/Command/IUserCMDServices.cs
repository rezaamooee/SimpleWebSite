using Common.Messages;
using Common.ViewModel.User;
using Entity.DBEntities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.User.Command
{
    public interface IUserCMDServices
    {
        public Task<RespMsg<EntUser>> Add(UserVM ReqAdd, CancellationToken CT);
        public  Task<RespMsg<EntUser>> Edit(UserVM ReqEdit, CancellationToken CT);
        public Task<RespMsg<EntUser>> Delete(long ReqDelID, CancellationToken CT);
    }
}
