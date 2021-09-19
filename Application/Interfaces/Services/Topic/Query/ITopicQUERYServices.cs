using Common.Messages;
using Common.ViewModel.Role;
using Common.ViewModel.Topic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Topic
{
    public interface ITopicQUERYServices
    {
        public  Task<bool> IfExist(long ReqID, bool? IsActive, CancellationToken CT);
        public  Task<bool> IfExist(TopicVM ReqVM, bool? IsActive, CancellationToken CT);
        public  Task<RespMsg<TopicVM>> Get(long ReqID, bool? IsActive, CancellationToken CT);
        public  Task<RespMsg<TopicVM>> Get(string ReqTopicTitle, bool? IsActive, CancellationToken CT);
        public  Task<RespMsg_List<TopicVM>> Filter(TopicFilterVM ReqFilter, CancellationToken CT);
        public  Task<RespMsg_List<TopicVM>> GetAll(bool? IsActive, CancellationToken CT);
        public  Task<RespMsg_List<TopicVM>> Getchild(long ReqID, bool? IsActive, CancellationToken CT);
        public  Task<TopicVM> Get(long ReqID, CancellationToken CT);


    }
}
