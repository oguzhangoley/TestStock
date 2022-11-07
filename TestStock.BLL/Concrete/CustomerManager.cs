using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.CustomerDtos;
using TestStock.Dto.UserDtos;
using TestStock.Entity;

namespace TestStock.BLL.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IDataResponse<bool> Add(CustomerCreateDto customerCreateDto)
        {
            var addedCustomer = new Customer
            {
                CustomerName = customerCreateDto.CustomerName,
                CustomerSurname = customerCreateDto.CustomerSurname,
                PhoneNumber = customerCreateDto.PhoneNumber,
                UserName = customerCreateDto.UserName,  
                Email = customerCreateDto.Email,
                Password=customerCreateDto.Password,

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

                return new DataResponse<bool>(true, true, "customer updated");
            }
            return new DataResponse<bool>(false, false, "customer could not be updated");
        }
    }
}
