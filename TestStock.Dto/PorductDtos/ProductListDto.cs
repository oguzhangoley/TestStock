using TestStock.Core.Entity;

namespace TestStock.Dto.PorductDtos
{
    public class ProductListDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string CategoryName { get; set; }
    }

}
