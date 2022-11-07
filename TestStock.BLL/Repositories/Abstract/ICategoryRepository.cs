using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Response;
using TestStock.DAL.Abstract;
using TestStock.Dto.CategoryDtos;
using TestStock.Entity;

namespace TestStock.BLL.Repositories.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {


        Category GetAll(int CategoryId);
        Category GetCategory(int CategoryId);
        Category Add(int CategoryId);
        Category Remove(int CategoryId);
        Category Delete(int CategoryId);







    }
}
