using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Common.Common
{
    public class ActionResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public ActionResponse()
        {
            Data = default(T);
            Success = false;
            Message = string.Empty;
        }
    }
}
