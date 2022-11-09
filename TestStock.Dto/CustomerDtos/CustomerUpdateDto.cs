using TestStock.Core.Entity;

namespace TestStock.Dto.UserDtos
{
    public class CustomerUpdateDto : IDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
    }
}
