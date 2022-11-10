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
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IOrderRepository _orderRepository;

        //Product product = new Product();

        Customer customer = new Customer();

        public OrderManager(IProductService productService, ICustomerService customerService, IOrderRepository orderRepository)
        {
            _productService = productService;

            _customerService = customerService;
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
            var orders = _orderRepository.GetAll();
            if (orders == null)
            {
                return new DataResponse<List<OrderListDto>>(null, false, "orders not found");

            }

            //var product=_productService.GetProductById(orders.)
            var ordersListDto = new List<OrderListDto>();


            foreach (var order in orders)
            {
                int price = (int)_productService.GetProductById(order.ProductId).Data.Price;

                ordersListDto.Add(new OrderListDto
                {

                    Id = order.Id,
                    CustomerId = order.CustomerId,
                    ProductId = order.ProductId,

                    ProductName = _productService.GetProductById(order.ProductId).Data.Name,
                    OrderStatus = true,
                    //TotalPrice = order.TotalPrice,
                    TotalPrice = price * order.Totalquantity,
                    Totalquantity = order.Totalquantity,
                });
            }
            return new DataResponse<List<OrderListDto>>(ordersListDto, true);
        }

        public IDataResponse<OrderListDto> GetOrderById(int id)
        {
            var order = _orderRepository.GetByFilter(x => x.Id == id);
            if (order == null)
            {
                return new DataResponse<OrderListDto>(null, false, "order not found");
            }

            var product = _productService.GetProductById(order.ProductId);
            var balance = _customerService.GetCustomerById(order.CustomerId).Data.Balance;

            if (order.TotalPrice > balance)
            {
                return new DataResponse<OrderListDto>(null, false, "balance is not enough");
            }
            order.TotalPrice = product.Data.Price * order.Totalquantity;
            // order.Balance = balance - (order.TotalPrice);
            order.OrderStatus = true;
            product.Data.Stock = (product.Data.Stock) - (int)(order.Totalquantity);

            _orderRepository.Update(order);

            OrderListDto orderListDto = new OrderListDto()
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                //ProductId = order.ProductId,    
                Balance = balance,
                OrderStatus = order.OrderStatus,
                Totalquantity = order.Totalquantity,
                TotalPrice = order.TotalPrice,
                ProductName = _productService.GetProductById(order.ProductId).Data.Name,

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
