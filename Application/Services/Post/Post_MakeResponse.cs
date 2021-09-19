using Common.Messages;
using Common.ViewModel.Post;
using Entity.DBEntities;
using System.Collections.Generic;


namespace Application.Services.Post
{
    public static class Post_MakeResponse
    {
        public static IResponseMessage MakeResponse<T>(List<(ServiceStatus ServiceStatus, string Message)> ServiceStatusMsg )
        {
            IResponseMessage Response;
            if ((typeof(T) == typeof(PostVM)))

                Response = new RespMsg<PostVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = null
                };
            else if ((typeof(T) == typeof(EntPost)))

                Response = new RespMsg<EntPost>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = null
                };
            else //((typeof(T) == typeof(PostAddVM)))
                Response = new RespMsg<PostAbsVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = null
                };
           
            return Response;
        }
        public static IResponseMessage MakeResponse<T>(EntPost Result, List<(ServiceStatus ServiceStatus, string Message)> ServiceStatusMsg )
        {
            IResponseMessage Response;
            if ((typeof(T) == typeof(PostVM)))
            {
                PostVM BuffList = null;
                if (Result != null)
                    BuffList = new PostVM(Result);
                Response = new RespMsg<PostVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            else if ((typeof(T) == typeof(EntPost)))
            {
                EntPost BuffList = null;
                if (Result != null)
                    BuffList = Result;
                Response = new RespMsg<EntPost>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            else //((typeof(T) == typeof(PostAddVM)))
            {
                PostAbsVM BuffList = null;
                if (Result != null)
                    BuffList = new PostAbsVM(Result);
                Response = new RespMsg<PostAbsVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            return Response;
        }
        public static IResponseMessage MakeResponse<T>(List<EntPost> ResultList, List<(ServiceStatus ServiceStatus, string Message)> ServiceStatusMsg )
        {
            IResponseMessage Response;
            if ((typeof(T) == typeof(PostVM)))
            {
                List<PostVM> BuffList = null;
                if (ResultList != null)
                {
                    BuffList = new List<PostVM>();
                    ResultList.ForEach(x => BuffList.Add(new PostVM(x)));
                }
                Response = new RespMsg_List<PostVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            else if ((typeof(T) == typeof(EntPost)))
            {
                List<EntPost> BuffList = null;
                if (ResultList != null)
                    BuffList =ResultList;
                Response = new RespMsg_List<EntPost>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = ResultList
                };
            }
            else // ((typeof(T) == typeof(PostAddVM)))
            {
                List<PostAbsVM> BuffList = null;
                if (ResultList != null)
                {
                    BuffList = new List<PostAbsVM>();
                    ResultList.ForEach(x => BuffList.Add(new PostAbsVM(x)));
                }
                Response = new RespMsg_List<PostAbsVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            return Response;
        }
    }
}
