using Common.Messages;
using Common.ViewModel.User;
using Entity.DBEntities;
using System.Collections.Generic;


namespace Application.Services.User
{
    public static class User_MakeResponse
    {
        public static IResponseMessage MakeResponse<T>(List<(ServiceStatus ServiceStatus, string Message)> ServiceStatusMsg )
        {
            IResponseMessage Response;
            if ((typeof(T) == typeof(UserAbsVM)))

                Response = new RespMsg<UserAbsVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = null
                };
            else if ((typeof(T) == typeof(UserInfoVM)))
                Response = new RespMsg<UserInfoVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = null
                };
            else if ((typeof(T) == typeof(UserLoginVM)))
            {
                Response = new RespMsg<UserLoginVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = null
                };
            }
            else if ((typeof(T) == typeof(UserVM)))
            {
                Response = new RespMsg<UserVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = null
                };
            }

            else//EntUser
                Response = new RespMsg<EntUser>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = null
                };

            return Response;
        }
        public static IResponseMessage MakeResponse<T>(EntUser Result, List<(ServiceStatus ServiceStatus, string Message)> ServiceStatusMsg )
        {
            IResponseMessage Response;
            if ((typeof(T) == typeof(UserAbsVM)))
            {
                UserAbsVM BuffList = null;
                if (Result != null)
                    BuffList = new UserAbsVM(Result);
                Response = new RespMsg<UserAbsVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            else if ((typeof(T) == typeof(UserInfoVM)))
            {
                UserInfoVM BuffList = null;
                if (Result != null)
                    BuffList = new UserInfoVM(Result);
                Response = new RespMsg<UserInfoVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            else if ((typeof(T) == typeof(UserLoginVM)))
            {
                UserLoginVM BuffList = null;
                if (Result != null)
                    BuffList = new UserLoginVM(Result);
                Response = new RespMsg<UserLoginVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            else if ((typeof(T) == typeof(UserVM)))
            {
                UserVM BuffList = null;
                if (Result != null)
                    BuffList = new UserVM(Result);
                Response = new RespMsg<UserVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            else//EntUser
                Response = new RespMsg<EntUser>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = Result
                };
            return Response;
        }
        public static IResponseMessage MakeResponse<T>(List<EntUser> ResultLiset, List<(ServiceStatus ServiceStatus, string Message)> ServiceStatusMsg )
        {
            IResponseMessage Response;
            if ((typeof(T) == typeof(UserAbsVM)))
            {
                List<UserAbsVM> BuffList = null;
                if (ResultLiset != null)
                {
                    BuffList = new List<UserAbsVM>();
                    ResultLiset.ForEach(x => BuffList.Add(new UserAbsVM(x)));
                }
                Response = new RespMsg_List<UserAbsVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            else if ((typeof(T) == typeof(UserInfoVM)))
            {
                List<UserInfoVM> BuffList = null;
                if (ResultLiset != null)
                {
                    BuffList = new List<UserInfoVM>();
                    ResultLiset.ForEach(x => BuffList.Add(new UserInfoVM(x)));
                }
                Response = new RespMsg_List<UserInfoVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            else if ((typeof(T) == typeof(UserLoginVM)))
            {
                List<UserLoginVM> BuffList = null;
                if (ResultLiset != null)
                {
                    BuffList = new List<UserLoginVM>();
                    ResultLiset.ForEach(x => BuffList.Add(new UserLoginVM(x)));
                }
                Response = new RespMsg_List<UserLoginVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            else if ((typeof(T) == typeof(UserVM)))
            {
                List<UserVM> BuffList = null;
                if (ResultLiset != null)
                {
                    BuffList = new List<UserVM>();
                    ResultLiset.ForEach(x => BuffList.Add(new UserVM(x)));
                }
                Response = new RespMsg_List<UserVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            }
            else//EntUser
            {
                Response = new RespMsg_List<EntUser>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = ResultLiset
                };

            }
            return Response;
        }
    }
}
