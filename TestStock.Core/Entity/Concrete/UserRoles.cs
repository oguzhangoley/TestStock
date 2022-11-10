using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStock.Core.Entity.Concrete
{
    public class UserRoles : IEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int Id { get; set; }
    }
}
