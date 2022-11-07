using TestStock.Core.Entity;

namespace TestStock.Dto.PorductDtos
{
    public class ProductListDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

}
