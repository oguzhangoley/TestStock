using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity;

namespace TestStock.Entity
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public int SalesQuantity { get; set; }

        public DateTime OrderCustomer { get; set; }




    }
}
