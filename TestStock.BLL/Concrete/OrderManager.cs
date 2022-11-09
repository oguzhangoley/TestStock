using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.OrderDtos;
using TestStock.Dto.PorductDtos;
using TestStock.Entity;

namespace TestStock.BLL.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICategoryRepository  _categoryRepository;
        private readonly IProductRepository _productRepository;
        public OrderManager(IOrderRepository orderRepository, ICategoryRepository categorRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _categoryRepository = categorRepository;
            _productRepository = productRepository;

        }

        public IDataResponse<bool> Add(OrderCreateDto orderCreateDto)
        {
            var addedOrder = new Order
            {
               OrderId=orderCreateDto.OrderId,
            };
            _orderRepository.Add(addedOrder);
            return new DataResponse<bool>(true, true, "addedOrder");


        }

        public IDataResponse<bool> Delete(int id)
        {
            var deletorder = _orderRepository.GetAllByFilter(x => x.OrderId == id);
            return new DataResponse<bool>(true, true, "order silindi");
        }

        public IDataResponse<List<OrderListDto>> GetAllOrders()
        {
            var orders = _orderRepository.GetAll();
            if (orders == null)
            {
                return new DataResponse<List<OrderListDto>>(null, false, "orders not found");
            }
            var ordersListDto = new List<OrderListDto>();
            foreach (var order in orders)
            {
                ordersListDto.Add(new OrderListDto
                {
                    OrderId = order.OrderId,
                    
                });
            }
            return new DataResponse<List<OrderListDto>>(ordersListDto, true);
        }

        public IDataResponse<OrderListDto> GetOrderByFilter(Expression<Func<Order, bool>> filter)
        {
            var order = _orderRepository.GetByFilter(filter);
            var orderListDto = new OrderListDto
            {
                OrderId = order.OrderId,
                
            };
            return new DataResponse<OrderListDto>(orderListDto, true);
        }

        public IDataResponse<List<OrderListDto>> GetOrdersByFilter(Expression<Func<Order, bool>> filter)
        {
            var orders = _orderRepository.GetAllByFilter(filter);
            if (orders == null)
            {
                return new DataResponse<List<OrderListDto>>(null, false, "orders not found");
            }
            var orderListDto = new List<OrderListDto>();
            foreach (var order in orders)
            {
                orderListDto.Add(new OrderListDto
                {
                    OrderId = order.OrderId,

                });
            }
            return new DataResponse<List<OrderListDto>>(orderListDto, true);
        }

        public IDataResponse<OrderListDto> GetOrdertById(int id)
        {
            var order = _orderRepository.GetByFilter(x => x.OrderId == id);
            var orderListDto = new OrderListDto
            {
                OrderId = order.OrderId,
              
            };
            return new DataResponse<OrderListDto>(orderListDto, true);
        }

        public IDataResponse<bool> Update(OrderUpdateDto orderUpdateDto)
        {
            var order = _orderRepository.GetByFilter(x => x.CategoryId == orderUpdateDto.OrderId);
            order.OrderId = orderUpdateDto.OrderId;
            _orderRepository.Update(order);
            return new DataResponse<bool>(true, true, " updated");
        }
    }
}
