using Common.Messages;
using Common.ViewModel.Post;
using Entity.DBEntities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Post.Command
{
    public interface IPostCMDServices
    {
        public  Task<RespMsg<EntPost>>  Add(PostAddVM ReqAdd, CancellationToken CT);
        public  Task<RespMsg<EntPost>> Edit(PostVM ReqEdit, CancellationToken CT);
        public  Task<RespMsg<EntPost>> Delete(long ReqDelID, CancellationToken CT);
    }
}
