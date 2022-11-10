﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity.Concrete;
using TestStock.Core.Response;
using TestStock.DAL.Abstract;
using TestStock.Entity;

namespace TestStock.BLL.Repositories.Abstract
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        //IDataResponse<List<Roles>> GetCustomers(Customer customer);

    }
}
