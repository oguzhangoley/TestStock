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
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public int UserId { get; set; }

    }
}
