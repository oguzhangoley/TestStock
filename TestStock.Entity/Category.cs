using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity;

namespace TestStock.Entity
{
    public class Category : IEntity
    {
        //public Category()
        //{
        //    List<Product> products = new List<Product>();
           
        //}
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }

        //public bool Status { get; set; }
        //public Collection<Product> Products { get; set; }



    }
}
