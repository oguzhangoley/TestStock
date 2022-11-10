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
        public int Id { get; set; }
        public int CustomerId { get; set; }
       // public HGHGHGH HGHGHGH { get; set; }
        public int ProductId { get; set; }
        public bool OrderStatus { get; set; } 
        public decimal Totalquantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
