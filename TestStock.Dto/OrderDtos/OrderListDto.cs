using TestStock.Core.Entity;

namespace TestStock.Dto.OrderDtos
{
    public class OrderListDto : IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public int ProductAmount { get; set; }
    }

}
