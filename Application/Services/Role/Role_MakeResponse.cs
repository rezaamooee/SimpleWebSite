using Common.Messages;
using Common.ViewModel.Role;
using Entity.DBEntities;
using System.Collections.Generic;

namespace Application.Services.Role
{
    public static class Role_MakeResponse
    {
        public static IResponseMessage MakeResponse(List<(ServiceStatus ServiceStatus, string Message)> ServiceStatusMsg)
        {
            IResponseMessage Response;
            Response = new RespMsg<RoleVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = null
                };

            return Response;
        }
        public static IResponseMessage MakeResponse(EntRole Result, List<(ServiceStatus ServiceStatus, string Message)> ServiceStatusMsg)
        {
            IResponseMessage Response;
            
                RoleVM BuffList = null;
                if (Result != null)
                    BuffList =new RoleVM( Result);
                Response = new RespMsg<RoleVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            return Response;
        }
        public static IResponseMessage MakeResponse(List<EntRole> ResultLiset, List<(ServiceStatus ServiceStatus, string Message)> ServiceStatusMsg)
        {
            IResponseMessage Response;
            
            List<RoleVM> BuffList = null;
            if (ResultLiset != null)
            {
                BuffList = new List<RoleVM>();
                ResultLiset.ForEach(x => BuffList.Add(new RoleVM(x)));
            }
            Response = new RespMsg_List<RoleVM>()
                {
                    Messages = ServiceStatusMsg,
                    ResultObject = BuffList
                };
            return Response;
        }
    }
}
