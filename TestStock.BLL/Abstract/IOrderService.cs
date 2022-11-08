using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.OrderDtos;

namespace TestStock.BLL.Abstract
{
    public interface IOrderService
    {
        IDataResponse<OrderCreateDto> Add(OrderCreateDto orderCreateDto);
        IDataResponse<bool> Update(OrderUpdateDto orderUpdateDto);
        IDataResponse<bool> Delete(int id);
        IDataResponse<List<OrderListDto>> GetAllOrders();

    }
}
