using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity;

namespace TestStock.Entity
{
    public class UserRoles:IEntity
    {
        public int UserId{ get; set; }
        public int RoleId { get; set; }

    }
}
