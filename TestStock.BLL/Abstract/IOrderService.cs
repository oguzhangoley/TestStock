using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Response;
using TestStock.Dto.OrderDtos;
using TestStock.Entity;

namespace TestStock.BLL.Abstract
{
    public interface IOrderService
    {
        IDataResponse<bool> AddOrder(OrderCreateDto orderCreateDto);
        IDataResponse<bool> UpdateOrder(OrderUpdateDto orderUpdateDto);
        IDataResponse<bool> DeleteOrder(int id);
        IDataResponse<List<OrderListDto>> GetAllOrders();
        IDataResponse<List<Order>> GetOrdersByFilter(Expression<Func<Order, bool>> filter);
        IDataResponse<OrderListDto> GetOrderById(int id);
    }
}
