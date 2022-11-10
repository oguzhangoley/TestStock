using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.Core.Entity.Concrete;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.OrderDtos;
using TestStock.Dto.UserDtos;
using TestStock.Entity;

namespace TestStock.BLL.Concrete
{
    public class OrderManager : IOrderService
    {
        //private readonly IProductService _productService;
        //private readonly ICustomerService _customerService;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly IOrderRepository _orderRepository;

        //Product product = new Product();

        Customer customer = new Customer();

        public OrderManager(IProductRepository productRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;

            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public IDataResponse<bool> AddOrder(OrderCreateDto orderCreateDto)
        {

            //var product=_productService.GetProductById(orderCreateDto.ProductId).Data.Id; //
            //var customerId = _customerService.GetCustomerById(orderCreateDto.CustomerId).Data.Id;
            var addedOrder = new Order
            {
                CustomerId = orderCreateDto.CustomerId,
                ProductId = orderCreateDto.ProductId,
                Totalquantity = orderCreateDto.Totalquantity,
               

            };

            _orderRepository.Add(addedOrder);
            return new DataResponse<bool>(true, true, "order added");
        }

        public IDataResponse<bool> DeleteOrder(int id)
        {
            var deletedOrder = _orderRepository.GetByFilter(x => x.Id == id);
            if (deletedOrder == null)
            {
                return new DataResponse<bool>(false, false, " order not found");
            }
            _orderRepository.Delete(deletedOrder);
            return new DataResponse<bool>(true, true, "order deleted");
        }

        public IDataResponse<List<OrderListDto>> GetAllOrders()
        {
            //ORDER I LİSTTE TUTUNCA PROPLARIM GELMİYOR SEBEBİNİ ARAŞTIR
            
            var orders = _orderRepository.GetAll();
            var orderListDto=new List<OrderListDto>();

            //var customer = _customerRepository.GetByFilter(x => x.Id == ordersListDto.CustomerId);

            //var product = _productRepository.GetByFilter(x => x.Id == ordersListDto.ProductId);
            if (orders == null)
            {
                return new DataResponse<List<OrderListDto>>(null, false, "orders not found");

            }

            //var product=_productService.GetProductById(orders.)

            //var order = new Order()
            //{
            //    Id = orderListDto,
            //    CustomerId = customer.Id,
            //    ProductId = product.Id,
            //    OrderStatus = ordersListDto.OrderStatus,
            //    TotalPrice = product.Price * ordersListDto.Totalquantity,
            //    Totalquantity = ordersListDto.Totalquantity,

            //};
            

            foreach (var order in orders)
            {
                var product = _productRepository.GetByFilter(x => x.Id == order.ProductId);
                if (order.TotalPrice > customer.Balance)
                {
                    return new DataResponse<List<OrderListDto>>(null, false, "balance is not enough");
                }


                _orderRepository.Update(order);
                orderListDto.Add(new OrderListDto
                {

                    Id = order.Id,
                    CustomerName=customer.CustomerName,
                    ProductName =product.Name,
                    OrderStatus = true,
                    TotalPrice = product.Price * order.Totalquantity,
                    Totalquantity = order.Totalquantity,
                    Balance=customer.Balance -order.TotalPrice
                });
            }
            return new DataResponse<List<OrderListDto>>(orderListDto, true);

        }

        public IDataResponse<OrderListDto> GetOrderById(int id)
        {
            var order = _orderRepository.GetByFilter(x => x.Id == id);
            if (order == null)
            {
                return new DataResponse<OrderListDto>(null, false, "order not found");
            }

            var _product=_productRepository.GetByFilter(x => x.Id == id);   
            var customer =_customerRepository.GetByFilter(x => x.Id == id);

            if (order.TotalPrice > customer.Balance)
            {
                return new DataResponse<OrderListDto>(null, false, "balance is not enough");
            }
          

            _orderRepository.Update(order);

            OrderListDto orderListDto = new OrderListDto()
            {
                Id = order.Id,
                //CustomerId = order.CustomerId,
                CustomerName=customer.CustomerName,
                //ProductId = _product.Id,    
                OrderStatus = order.OrderStatus,
                Totalquantity = order.Totalquantity,
                TotalPrice = _product.Price*order.Totalquantity,
                Balance = customer.Balance - order.TotalPrice,
                ProductName = _product.Name,

            };




            return new DataResponse<OrderListDto>(orderListDto, true);
        }


        public IDataResponse<List<Order>> GetOrdersByFilter(Expression<Func<Order, bool>> filter)
        {
            throw new NotImplementedException();


        }

        public IDataResponse<bool> UpdateOrder(OrderUpdateDto orderUpdateDto)
        {
            if (orderUpdateDto != null)
            {
                var order = _orderRepository.GetByFilter(x => x.Id == orderUpdateDto.Id);
                order.Id = orderUpdateDto.Id;
                order.CustomerId = orderUpdateDto.CustomerId;
                order.TotalPrice = orderUpdateDto.TotalPrice;
                order.ProductId = orderUpdateDto.ProductId;
                order.OrderStatus = orderUpdateDto.OrderStatus;
                order.Totalquantity = orderUpdateDto.Totalquantity;
                order.TotalPrice = orderUpdateDto.TotalPrice;

                return new DataResponse<bool>(true, true, "order updated");
            }
            return new DataResponse<bool>(false, false, "order could not be updated");
        }
    }
}
