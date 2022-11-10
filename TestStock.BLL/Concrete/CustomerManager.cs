using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.Core.Entity.Concrete;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.CustomerDtos;
using TestStock.Dto.RolesDtos;
using TestStock.Dto.UserDtos;
using TestStock.Entity;

namespace TestStock.BLL.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerRoleRepository _customerRoleRepository;
        private readonly IRolesRepository _rolesRepository;

        public CustomerManager(ICustomerRepository customerRepository, ICustomerRoleRepository customerRoleRepository, IRolesRepository rolesRepository)
        {
            _customerRepository = customerRepository;
            _customerRoleRepository = customerRoleRepository;
            _rolesRepository = rolesRepository;
        }

        public IDataResponse<bool> Add(CustomerCreateDto customerCreateDto)
        {
            var addedCustomer = new Customer()
            {
                CustomerName = customerCreateDto.CustomerName,
                CustomerSurname = customerCreateDto.CustomerSurname,
                PhoneNumber = customerCreateDto.PhoneNumber,
                UserName = customerCreateDto.UserName,  
                Email = customerCreateDto.Email,
                Password=customerCreateDto.Password,
                Balance = customerCreateDto.Balance,

            };
            _customerRepository.Add(addedCustomer);
            return new DataResponse<bool>(true, true, "customer added");
        }

        public IDataResponse<bool> Delete(int id)
        {
            var deletedCustomer = _customerRepository.GetByFilter(x => x.Id == id);
            if (deletedCustomer==null)
            {
                return new DataResponse<bool>(false, false, "customer not found");
            }
            _customerRepository.Delete(deletedCustomer);
            return new DataResponse<bool>(true, true, "customer deleted");
        }

        public IDataResponse<List<CustomerListDto>> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll();
            if (customers==null)
            {
                return new DataResponse<List<CustomerListDto>>(null, false, "customera not found");

            }
            var customersListDto = new List<CustomerListDto>();
            foreach (var customer in customers)
            {
                customersListDto.Add(new CustomerListDto
                {
                    Id = customer.Id,
                    CustomerName = customer.CustomerName,
                    CustomerSurname = customer.CustomerSurname,
                    PhoneNumber = customer.PhoneNumber,
                    UserName = customer.UserName,
                    Email = customer.Email,
                    Balance = customer.Balance,
                    
                   

                    Password = customer.Password,
                    
                });
            }
            return new DataResponse<List<CustomerListDto>>(customersListDto, true);
        }

        public IDataResponse<CustomerListDto> GetCustomerById(int customerId)
        {
            var customer = _customerRepository.GetByFilter(x => x.Id == customerId);
            var customerListDto = new CustomerListDto
            {
                Id = customer.Id,
                CustomerName = customer.CustomerName,
                CustomerSurname = customer.CustomerSurname,
                PhoneNumber = customer.PhoneNumber,
                UserName = customer.UserName,
                Email = customer.Email,
                Balance= customer.Balance,
                Password = customer.Password,
            };
            return new DataResponse<CustomerListDto>(customerListDto, true);
        }

        public IDataResponse<List<CustomerListDto>> GetCustomersByFilter(Expression<Func<Customer, bool>> filter)
        {
          var customers=_customerRepository.GetAllByFilter(filter);
            if (customers == null)
            {
                return new DataResponse<List<CustomerListDto>>(null, false, "customers not found");
            }
            var customersListDto=new List<CustomerListDto>();
            foreach  (var customer in customers)
            {
                customersListDto.Add(new CustomerListDto
                {
                    Id = customer.Id,
                    CustomerName = customer.CustomerName,
                    CustomerSurname = customer.CustomerSurname,
                    PhoneNumber = customer.PhoneNumber,
                    UserName = customer.UserName,
                    Email = customer.Email,
                    Balance = customer.Balance,
                    Password = customer.Password,
                });
            }
            return new DataResponse<List<CustomerListDto>>(customersListDto, true);

        }

        public IDataResponse<bool> Update(CustomerUpdateDto customerUpdateDto)
        {
            if (customerUpdateDto != null)
            {
                var customer = _customerRepository.GetByFilter(x => x.Id == customerUpdateDto.Id);
                customer.Id = customerUpdateDto.Id;
                customer.CustomerName = customerUpdateDto.CustomerName;
                customer.CustomerSurname = customerUpdateDto.CustomerSurname;
                customer.PhoneNumber = customerUpdateDto.PhoneNumber;
                customer.UserName = customerUpdateDto.UserName;
                customer.Email = customerUpdateDto.Email;
                customer.Password = customerUpdateDto.Password;
                customer.Balance = customerUpdateDto.Balance;

                return new DataResponse<bool>(true, true, "customer updated");
            }
            return new DataResponse<bool>(false, false, "customer could not be updated");
        }

        public IDataResponse<Customer> GetCustomerByMail(string mail)
        {
            var customer = _customerRepository.GetByFilter(x => x.Email == mail);
            if(customer == null)
            {
                return new DataResponse<Customer>(null, false, "customer not found");
            }
            return new DataResponse<Customer>(customer, true);
        }

        public IDataResponse<List<Roles>> GetCustomers(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<CustomerRoleNamesDto> GetCustomerWithRoleName()
        {
            var repository = _customerRepository.GetAll();
            var customerRoleName = new List<CustomerRoleNamesDto>();

            foreach (var item in repository)
            {
                var getCustomerRoles = _customerRoleRepository.GetAllByFilter(x => x.CustomerId == item.Id).FirstOrDefault();
                //var getRoleName = _rolesService.GetRolesById(getCustomerRoles.RoleId);
                //var getRoleName = _rolesRepository.GetAllByFilter(x => x.Id==item.Id).FirstOrDefault();

                customerRoleName.Add(new CustomerRoleNamesDto
                {
                    userName = item.UserName,
                    roleName=""
                });

            }
            return customerRoleName;
        }
    }
}
