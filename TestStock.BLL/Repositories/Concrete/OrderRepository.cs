﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Repositories.Abstract;
using TestStock.DAL.Concrete;
using TestStock.DAL.Context;
using TestStock.Entity;

namespace TestStock.BLL.Repositories.Concrete
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ProjectDbContext context) : base(context)
        {
        }

        public Order Add(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Order Delete(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public Order GetAll(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Order Remove(int OrderId)
        {
            throw new NotImplementedException();
        }
    }
}
