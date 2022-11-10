using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity.Concrete;
using TestStock.DAL.Abstract;
using TestStock.DAL.Context;
using TestStock.Dto.RolesDtos;

namespace TestStock.DAL.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
       
        private readonly ProjectDbContext _context;
        private readonly IRepository<Customer> _repository;
        public CustomerRepository(ProjectDbContext context, ICustomerRepository customerRepository, IRepository<Customer> repository)
        {
            _context = context;
            
            _repository = repository;
        }

        public List<CustomerRoleNamesDto> GetCustomerWithRoleName()
        {
            var repository = _repository.GetAll();
            var customerRoleName = new List<CustomerRoleNamesDto>();

            foreach (var item in repository)
            {
                customerRoleName.Add(new CustomerRoleNamesDto
                {
                    userName = item.UserName,
                    roleName=""
                });

            }
            return customerRoleName;
        }

        public List<Roles> GetRoles(Customer customer)
        {
            using (var context = _context) {

                var result = from roles in context.Roles
                             join customerRoles in context.CustomerRoles
                             on roles.Id equals customerRoles.RoleId
                             where customerRoles.CustomerId == customer.Id
                             select new Roles {  Id=roles.Id, Name=roles.Name };

                return result.ToList();
                           
            };
        }

      
    }
}
