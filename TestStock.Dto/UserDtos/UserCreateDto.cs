using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity;

namespace TestStock.Dto.UserDtos
{
    public class UserCreateDto : IDto
    {
     
        public string UserName{get;set; }
        public string email { get; set; }
        public string  password { get; set; }

    }
}
