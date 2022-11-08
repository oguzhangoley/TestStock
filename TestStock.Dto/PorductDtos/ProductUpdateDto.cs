using TestStock.Core.Entity;

namespace TestStock.Dto.PorductDtos
{
    public class ProductUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int CategoryId { get; set; }
    }

}
