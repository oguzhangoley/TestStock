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
        private readonly IUserRoleRepository _userRoleRepository;
        public UserRepository(ProjectDbContext context, IUserRoleRepository userRoleRepository) : base(context)
        {
            _userRoleRepository = userRoleRepository;
        }

        public List<Role> GetClaims(User user)
        {
            return _userRoleRepository.GetClaims(user);
        }
    }
}
