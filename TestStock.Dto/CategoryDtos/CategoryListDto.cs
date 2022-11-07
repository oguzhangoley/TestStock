using TestStock.Core.Entity;

namespace TestStock.Dto.CategoryDtos
{
    public class CategoryListDto : IDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
