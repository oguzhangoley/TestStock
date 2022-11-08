using TestStock.Core.Entity;

namespace TestStock.Dto.UserDtos
{
    public class UserListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public decimal Balance { get; set; }

    }
}
