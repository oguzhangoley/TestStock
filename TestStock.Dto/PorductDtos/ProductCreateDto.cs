using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity;

namespace TestStock.Dto.PorductDtos
{
    public class ProductCreateDto : IDto
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int CategoryId { get; set; }
    }

}
