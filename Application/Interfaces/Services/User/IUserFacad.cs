using Common.Messages;
using Common.ViewModel.User;
using Entity.DBEntities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.User
{
    public interface IUserFacad
    {

        public Task<RespMsg<EntUser>> Add(UserVM newUser , CancellationToken CT);
        public Task<RespMsg<EntUser>> Edit(UserVM ReqEdit, CancellationToken CT);
        public Task<RespMsg<EntUser>> Delete(long ID, CancellationToken CT);
        public Task<bool> IfExist(long ID, bool? IsActiveUser, CancellationToken CT);
        public Task<bool> IfExist(UserLoginVM ReqVM, bool? IsActiveUser, CancellationToken CT);
        public Task<RespMsg<T>> Get<T>(long ID, bool? IsActiveUser, CancellationToken CT);
        public Task<RespMsg<T>> Get<T>(UserLoginVM ReqVM, bool? IsActiveUser, CancellationToken CT);
        public Task<RespMsg_List<T>> Filter<T>(UserFilterVM ReqFilter, CancellationToken CT);
        public Task<RespMsg_List<T>> GetAll<T>(bool? IsActiveUser, CancellationToken CT);

    }
}