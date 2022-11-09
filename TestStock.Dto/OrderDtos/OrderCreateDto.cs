using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity;

namespace TestStock.Dto.OrderDtos
{
    public class OrderCreateDto : IDto
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        //public decimal Balance { get; set; }
        //public bool OrderStatus { get; set; }
        public int Totalquantity { get; set; }
        //public decimal TotalPrice { get; set; }

    }

}
