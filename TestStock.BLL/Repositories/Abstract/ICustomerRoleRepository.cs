using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity.Concrete;
using TestStock.DAL.Abstract;

namespace TestStock.BLL.Repositories.Abstract
{
    public interface ICustomerRoleRepository:IRepository<CustomerRoles>
    {
    }
}
