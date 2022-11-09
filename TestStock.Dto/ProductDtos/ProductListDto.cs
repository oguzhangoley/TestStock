using TestStock.Core.Entity;

namespace TestStock.Dto.PorductDtos
{
    public class ProductListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public int OrderId { get; set; }
    }

}
