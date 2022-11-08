using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.DAL.Abstract;
using TestStock.Entity;

namespace TestStock.BLL.Repositories.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetAll(int id);
        Product GetProduct(int id);
        Product Add(int id);
        Product Remove (int id);
        Product Delete(int id);
        void Update(List<Product> product);
    }
}
