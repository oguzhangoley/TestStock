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
        private readonly ICategoryRepository _categoryRepository;
        public CategoryRepository(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

    }
}
