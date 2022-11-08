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
                OrderName = orderCreateDto.OrderName,
                ProductId=orderCreateDto.ProductId,
                CategoryId=orderCreateDto.CategoryId,
                OrderCustomer =orderCreateDto.OrderCustomer,
               
              
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


            throw new NotImplementedException();
        }

        public IDataResponse<List<OrderListDto>> GetOrdersByFilter(Expression<Func<Order, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<OrderListDto> GetOrdertById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<bool> Update(OrderUpdateDto orderUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
