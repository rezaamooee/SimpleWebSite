using Common.Messages;
using Common.ViewModel.Post;
using Entity.DBEntities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Post
{
    public interface IPostFacad
    {

        public Task<RespMsg<EntPost>> Add(PostAddVM ReqNew, CancellationToken CT);
        public Task<RespMsg<EntPost>> Edit(PostVM ReqEdit, CancellationToken CT);
        public Task<RespMsg<EntPost>> Delete(long ReqDelID, CancellationToken CT);
        public Task<bool> IfExist(long ID, bool? IsActive, CancellationToken CT);
        public Task<RespMsg<T>> Get<T>(long ID, bool? IsActive, CancellationToken CT);
        public Task<RespMsg_List<T>> GetAll<T>(bool? IsActive, CancellationToken CT);


    }
}