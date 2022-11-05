using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.DAL.Abstract;
using TestStock.Entity;

namespace TestStock.BLL.Repositories.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
