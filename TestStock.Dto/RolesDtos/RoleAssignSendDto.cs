using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStock.Dto.RolesDtos
{
    public class RoleAssignSendDto
    {
        public List<RoleAssignListDto> Roles { get; set; }
        public int CustomerId { get; set; }

    }
}
