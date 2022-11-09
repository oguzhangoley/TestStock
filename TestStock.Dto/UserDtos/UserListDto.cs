using TestStock.Core.Entity;

namespace TestStock.Dto.UserDtos
{
    public class UserListDto : IDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }


    }
}
