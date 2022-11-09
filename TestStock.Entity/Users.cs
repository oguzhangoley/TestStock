using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity;

namespace TestStock.Entity
{
    public class Users : IEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string mail { get; set; }
        public string password { get; set; }

    }
}
