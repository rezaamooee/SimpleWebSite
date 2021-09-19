using Common.Messages;
using Common.ViewModel.Post;
using Common.ViewModel.Topic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Post
{
    public interface IPostQUERYServices
    {
        public  Task<bool> IfExist(long ReqID, bool? IsActive, CancellationToken CT);
        public  Task<RespMsg<T>> Get<T>(long ReqID, bool? IsActive, CancellationToken CT);
        public  Task<RespMsg_List<T>> Filter<T>(PostFilter ReqFilter, CancellationToken CT);
        public  Task<RespMsg_List<T>> GetAll<T>(bool? IsActive, CancellationToken CT);
        
    }
}
