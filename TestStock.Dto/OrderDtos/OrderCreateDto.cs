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

        public int OrderUserId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }

}
