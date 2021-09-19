using System.Collections.Generic;

namespace Common.Messages
{
    public class RespMsg_List<T> : IResponseMessage
    {
        public List<T> ResultObject { set; get; }
        public List<(ServiceStatus ServiceStatus, string Message)> Messages { set; get; }
    }


    public class RespMsg<T> : IResponseMessage
    {
        public T ResultObject { set; get; }
        public List<(ServiceStatus ServiceStatus, string Message)> Messages { set; get; }
    }

}
