using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity;
using TestStock.Core.Entity.Concrete;

namespace TestStock.DAL.Abstract
{
    public interface IRepository<T> where T : IEntity 
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        List<T> GetAllByFilter(Expression<Func<T, bool>> filter);

        T GetByFilter(Expression<Func<T, bool>> filter);
    }
}
