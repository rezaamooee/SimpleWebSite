using Common.Messages;
using Common.ViewModel.Topic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Topic.Command
{
    public interface ITopicCMDServices
    {
        public Task<RespMsg<TopicVM>> Add(TopicVM ReqAdd, CancellationToken CT);
        public  Task<RespMsg<TopicVM>> Edit(TopicVM ReqEdit, CancellationToken CT);
        public Task<RespMsg<TopicVM>> Delete(long ReqDelID, CancellationToken CT);
    }
}
