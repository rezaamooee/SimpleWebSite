using Application.Interfaces.Contexts;
using Application.Interfaces.Services.Topic;
using Application.Services.Topic.Command;
using Application.Services.Topic.Query;
using Common.Messages;
using Common.ViewModel.Topic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Topic
{
    public class TopicFacad : ITopicFacad
    {
        private readonly ISiteDbContext _Context;
        public TopicFacad(ISiteDbContext context )
        {
            _Context = context;
        }
        public async Task<RespMsg<TopicVM>> Add(TopicVM ReqAdd, CancellationToken CT) => await new TopicCMDServices(_Context).Add(ReqAdd, CT);
        public async Task<RespMsg<TopicVM>> Edit(TopicVM ReqEdit, CancellationToken CT) => await new TopicCMDServices(_Context).Edit(ReqEdit, CT);
        public async Task<RespMsg<TopicVM>> Delete(long ReqDelID, CancellationToken CT) => await new TopicCMDServices(_Context).Delete(ReqDelID, CT);

        public async Task<bool> IfExist(long ReqID, bool? IsActive, CancellationToken CT) => await new TopicQUERYServices(_Context).IfExist(ReqID, IsActive, CT);
        public async Task<bool> IfExist(TopicVM ReqVM, bool? IsActive, CancellationToken CT) => await new TopicQUERYServices(_Context).IfExist(ReqVM, IsActive, CT);
        public async Task<RespMsg<TopicVM>> Get(long ReqID, bool? IsActive, CancellationToken CT) => await new TopicQUERYServices(_Context).Get( ReqID,  IsActive,  CT);
        public async Task<RespMsg<TopicVM>> Get(string ReqTopicTitle, bool? IsActive, CancellationToken CT) => await new TopicQUERYServices(_Context).Get(ReqTopicTitle, IsActive, CT);
        public async Task<RespMsg_List<TopicVM>> Filter(TopicFilterVM ReqFilter, CancellationToken CT) => await new TopicQUERYServices(_Context).Filter(ReqFilter, CT);
        public async Task<RespMsg_List<TopicVM>> GetAll(bool? IsActive, CancellationToken CT) => await new TopicQUERYServices(_Context).GetAll(IsActive, CT);
        public async Task<RespMsg_List<TopicVM>> Getchild(long ReqID, bool? IsActive, CancellationToken CT) => await new TopicQUERYServices(_Context).Getchild(ReqID, IsActive, CT);
        public async Task<TopicVM> Get(long ReqID, CancellationToken CT) => await new TopicQUERYServices(_Context).Get(ReqID, CT);
    }
}
