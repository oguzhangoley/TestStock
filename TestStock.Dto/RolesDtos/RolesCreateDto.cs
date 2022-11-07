using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity;

namespace TestStock.Dto.RolesDtos
{
    public class RolesCreateDto:IDto  
    {
        
        public string Name { get; set; }
    }
}
