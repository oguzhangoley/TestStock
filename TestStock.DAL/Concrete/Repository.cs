using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity;
using TestStock.DAL.Abstract;
using TestStock.DAL.Context;

namespace TestStock.DAL.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ProjectDbContext _context;

        public Repository(ProjectDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
           return _context.Set<T>().AsNoTracking().ToList();
        }

        public List<T> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().AsNoTracking().Where(filter).ToList();

        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(filter);

        }


        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
