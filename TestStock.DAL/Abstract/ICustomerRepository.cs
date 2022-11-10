using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity.Concrete;
using TestStock.Dto.RolesDtos;

namespace TestStock.DAL.Abstract
{
    public interface ICustomerRepository
    {
        List<Roles> GetRoles(Customer customer);
        List<CustomerRoleNamesDto> GetCustomerWithRoleName();
    }
}
