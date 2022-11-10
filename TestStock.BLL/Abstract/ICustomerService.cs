using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity.Concrete;
using TestStock.Core.Response;
using TestStock.Dto.CustomerDtos;
using TestStock.Dto.RolesDtos;
using TestStock.Dto.UserDtos;
using TestStock.Entity;

namespace TestStock.BLL.Abstract
{
    public interface ICustomerService
    {
        IDataResponse<bool> Add(CustomerCreateDto customerCreateDto);
        IDataResponse<bool> Update(CustomerUpdateDto customerUpdateDto);
        IDataResponse<bool> Delete(int id);

        IDataResponse<List<CustomerListDto>> GetAllCustomers();
        IDataResponse<List<CustomerListDto>> GetCustomersByFilter(Expression<Func<Customer, bool>> filter);

        IDataResponse<CustomerListDto> GetCustomerById(int customerId);
        IDataResponse<Customer> GetCustomerByMail(string mail);

        IDataResponse<List<Roles>> GetCustomers(Customer customer);
        List<CustomerRoleNamesDto> GetCustomerWithRoleName();


    }
}
