using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Repositories.Abstract;
using TestStock.Core.Entity.Concrete;
using TestStock.DAL.Concrete;
using TestStock.DAL.Context;

namespace TestStock.BLL.Repositories.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProjectDbContext context) : base(context)
        {
        }

        public object Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
