﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Repositories.Abstract;
using TestStock.Core.Entity.Concrete;
using TestStock.DAL.Concrete;
using TestStock.DAL.Context;
using TestStock.Entity;

namespace TestStock.BLL.Repositories.Concrete
{
    public class CustomerRepository : Repository<Core.Entity.Concrete.Customer>, ICustomerRepository
    {
        public CustomerRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
