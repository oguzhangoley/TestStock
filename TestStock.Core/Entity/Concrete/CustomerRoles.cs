using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStock.Core.Entity.Concrete
{
    public class CustomerRoles:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoleId { get; set; }
    }
}
