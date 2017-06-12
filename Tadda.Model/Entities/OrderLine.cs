using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadda.Model.Entities
{
    public class OrderLine
    {
        public OrderLine()
        {
            DateTimeCreated = DateTime.Now;
        }
        public int OrderLineID { get; set; }
        public string Description { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public DateTime DateTimeCreated { get; set; }

    }
}
