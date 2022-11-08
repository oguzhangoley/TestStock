using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.OrderDtos;
using TestStock.Entity;

namespace TestStock.BLL.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public OrderManager(IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public IDataResponse<OrderCreateDto> Add(OrderCreateDto orderCreateDto)
        {
            try
            {
                var user = _userRepository.GetByFilter(x => x.Id == orderCreateDto.OrderUserId);
                var product = _productRepository.GetByFilter(x => x.Id == orderCreateDto.ProductId);
                var unitPrice = product.UnitPrice;
                var orderTotalPrice = unitPrice * orderCreateDto.ProductQuantity;

                var order = new Order()
                {
                    UserId = orderCreateDto.OrderUserId,
                    ProductId = orderCreateDto.ProductId,
                    ProductQuantity = orderCreateDto.ProductQuantity,

                };

                if (orderCreateDto.ProductQuantity <= product.UnitInStock)
                {
                    product.UnitInStock -= orderCreateDto.ProductQuantity;
                    _productRepository.Update(product);
                }
                else
                {
                    return new DataResponse<OrderCreateDto>(null, false, "stok yeterli degil");

                }

                if (user.Balance <= orderCreateDto.ProductQuantity)
                {
                    user.Balance -= orderCreateDto.ProductQuantity;
                    _orderRepository.Add(order);
                    _userRepository.Update(user);

                }
                else
                {
                    return new DataResponse<OrderCreateDto>(null, false, "bakiye yeterli degil");

                }
                return new DataResponse<OrderCreateDto>(orderCreateDto, true, "oldu");

            }
            catch (Exception e)
            {

                return new DataResponse<OrderCreateDto>(null,false,e.Message);
            }
           





        }

        public IDataResponse<bool> Delete(int id)
        {
            var deletedOrder = _orderRepository.GetByFilter(x => x.Id == id);
            if (deletedOrder == null)
            {
                return new DataResponse<bool>(false, false, "order not found gardas");

            }
            _orderRepository.Delete(deletedOrder);
            return new DataResponse<bool>(true, true, "order deleted");
        }

        public IDataResponse<List<OrderListDto>> GetAllOrders()
        {
            var orders = _orderRepository.GetAll();
            if (orders == null)
            {
                return new DataResponse<List<OrderListDto>>(null, false, "order not found");
            }
            var orderListDto = new List<OrderListDto>();
            foreach (var order in orders)
            {
                orderListDto.Add(new OrderListDto()
                {
                    Id = order.Id,
                    ProductName = _productRepository.GetByFilter(x => x.Id == order.ProductId).Name,
                    ProductAmount = order.ProductQuantity,
                    UserName = _userRepository.GetByFilter(x => x.Id == order.UserId).Username
                });
            }
            return new DataResponse<List<OrderListDto>>(orderListDto, true);
        }

        public IDataResponse<bool> Update(OrderUpdateDto orderUpdateDto)
        {
            var order = _orderRepository.GetByFilter(x => x.Id == orderUpdateDto.Id);
            order.ProductId = orderUpdateDto.ProductId;
            order.ProductQuantity = orderUpdateDto.Quantity;
            return new DataResponse<bool>(true, true, "guncellendi");
        }
    }
}
