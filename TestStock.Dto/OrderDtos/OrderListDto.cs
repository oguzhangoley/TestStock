using TestStock.Core.Entity;

namespace TestStock.Dto.OrderDtos
{
    public class OrderListDto : IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Balance { get; set; }
        public string ProductName { get; set; }
        public bool OrderStatus { get; set; }
        public decimal Totalquantity { get; set; }
        public decimal TotalPrice { get; set; }

    }

}
