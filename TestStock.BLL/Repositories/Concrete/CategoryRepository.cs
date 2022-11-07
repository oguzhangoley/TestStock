using System;
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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ProjectDbContext _context;
        public CategoryRepository(ProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public Category Add(int CategoryId)
        {
          
        }

        public Category Delete(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public Category GetAll(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public Category Remove(int CategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
