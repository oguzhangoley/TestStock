using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStock.Dto.UserDtos
{
    public class UserOrderDto
    {
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
