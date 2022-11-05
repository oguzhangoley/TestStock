using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStock.Core.Response
{
    public class Response : IResponse
    {
        public string Message { get; set; }
        public bool Status { get; set; }

        public Response(bool status)
        {
            Status = status;
        }

        public Response( bool status, string message)
        {
            Message = message;
            Status = status;
        }
    }
}
