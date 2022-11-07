using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.DAL.Abstract;
using TestStock.Entity;

namespace TestStock.BLL.Repositories.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetAll(int OrderId);
      
        Order Add(int OrderId);
        Order Remove(int OrderId);
        Order Delete(int CategoryId);

    }
}
