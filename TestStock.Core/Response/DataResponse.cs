using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStock.Core.Response
{
    public class DataResponse<T> : Response, IDataResponse<T>
    {
        
       

        public T Data { get; set; }

        public DataResponse(T data,bool status) : base(status)
        {
            Data = data;
        }

        public DataResponse(T data , bool status ,string message) : base(status , message)
        {
            Data=data;
        }

       
    }
}
