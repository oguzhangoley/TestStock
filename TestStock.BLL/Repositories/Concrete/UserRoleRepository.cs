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
    public class UserRoleRepository : Repository<UserRoles>, IUserRoleRepository
    {
        private readonly ProjectDbContext _context;
        public UserRoleRepository(ProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Role> GetClaims(User user)
        {


            using (var context = _context)
            {
                var result = from role in context.Roles
                             join userRole in context.UserRoles
                             on role.Id equals userRole.RoleId
                             where userRole.UserId == user.Id
                             select new Role { Id = role.Id, Name = role.Name };
                return result.ToList();
            }
        }


    }
}
