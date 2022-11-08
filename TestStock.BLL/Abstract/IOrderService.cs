using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Response;
using TestStock.Dto.OrderDtos;
using TestStock.Dto.PorductDtos;
using TestStock.Entity;

namespace TestStock.BLL.Abstract
{
    public interface IOrderService
    {
        IDataResponse<bool> Add(OrderCreateDto orderCreateDto);
        IDataResponse<bool> Update(OrderUpdateDto orderUpdateDto);
        IDataResponse<bool> Delete(int id);
        IDataResponse<List<OrderListDto>> GetAllOrders();
        IDataResponse<List<OrderListDto>> GetOrdersByFilter(Expression<Func<Order, bool>> filter);
        IDataResponse<OrderListDto> GetOrdertById(int id);







    }
}
