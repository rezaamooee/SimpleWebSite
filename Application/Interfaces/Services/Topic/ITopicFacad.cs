using Application.Services.Topic.Command;
using Common.Messages;
using Common.ViewModel.Topic;
using Entity.DBEntities;
using Entity.Tools;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Topic
{
    public interface ITopicFacad
    {

        public Task<RespMsg<TopicVM>> Add(TopicVM ReqAdd, CancellationToken CT);
        public Task<RespMsg<TopicVM>> Edit(TopicVM ReqEdit, CancellationToken CT);
        public Task<RespMsg<TopicVM>> Delete(long ReqDelID, CancellationToken CT);

        public Task<bool> IfExist(long ReqID, bool? IsActive, CancellationToken CT);
        public Task<bool> IfExist(TopicVM ReqVM, bool? IsActive, CancellationToken CT);
        public Task<RespMsg<TopicVM>> Get(long ReqID, bool? IsActive, CancellationToken CT);
        public Task<RespMsg<TopicVM>> Get(string ReqTopicTitle, bool? IsActive, CancellationToken CT);
        public Task<TopicVM> Get(long ReqID, CancellationToken CT);
        public Task<RespMsg_List<TopicVM>> Filter(TopicFilterVM ReqFilter, CancellationToken CT);
        public Task<RespMsg_List<TopicVM>> GetAll(bool? IsActive, CancellationToken CT);
        public Task<RespMsg_List<TopicVM>> Getchild(long ReqID, bool? IsActive, CancellationToken CT);


    }
}