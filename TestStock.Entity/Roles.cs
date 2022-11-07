using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity;

namespace TestStock.Entity
{
    public class Roles:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
