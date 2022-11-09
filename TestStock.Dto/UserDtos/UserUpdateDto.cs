using TestStock.Core.Entity;

namespace TestStock.Dto.UserDtos
{
    public class UserUpdateDto : IDto
    {
        public int UserId { get; set; }
    }
}
