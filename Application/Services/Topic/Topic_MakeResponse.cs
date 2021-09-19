using Common.Messages;
using Common.ViewModel.Role;
using Common.ViewModel.Topic;
using Entity.DBEntities;
using System.Collections.Generic;

namespace Application.Services.Role
{
    public static class Topic_MakeResponse
    {
        public static IResponseMessage MakeResponse(List<(ServiceStatus ServiceStatus, string Message)> ServiceStatusMsg)
        {
            IResponseMessage Response;
            Response = new RespMsg<TopicVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = null
                };

            return Response;
        }
        public static IResponseMessage MakeResponse(EntTopic Result, List<(ServiceStatus ServiceStatus, string Message)> ServiceStatusMsg)
        {
            IResponseMessage Response;

            TopicVM BuffList = null;
                if (Result != null)
                    BuffList =new TopicVM( Result);
                Response = new RespMsg<TopicVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            return Response;
        }
        public static IResponseMessage MakeResponse(List<EntTopic> ResultLiset, List<(ServiceStatus ServiceStatus, string Message)> ServiceStatusMsg)
        {
            IResponseMessage Response;
            
            List<TopicVM> BuffList = null;
            if (ResultLiset != null)
            {
                BuffList = new List<TopicVM>();
                ResultLiset.ForEach(x => BuffList.Add(new TopicVM(x)));
            }
            Response = new RespMsg_List<TopicVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            return Response;
        }
    }
}
