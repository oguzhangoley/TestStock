using TestStock.Core.Entity;

namespace TestStock.Dto.OrderDtos
{
    public class OrderUpdateDto : IDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
