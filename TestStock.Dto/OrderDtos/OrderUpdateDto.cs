using TestStock.Core.Entity;

namespace TestStock.Dto.OrderDtos
{
    public class OrderUpdateDto : IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public bool OrderStatus { get; set; }
        public decimal Totalquantity { get; set; }
        public decimal TotalPrice { get; set; }

    }

}
