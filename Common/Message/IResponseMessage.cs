using System.Collections.Generic;

namespace Common.Messages
{
    public interface IResponseMessage
    {
        public List<(ServiceStatus ServiceStatus, string Message)> Messages { get; set; }
    }
}