using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStock.Core.Response
{
    public interface IResponse
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
