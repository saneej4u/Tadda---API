using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadda.Model.Entities
{
    public class Order
    {
        public Order()
        {
            DateTimeCreated = DateTime.Now;
        }

        public int OrderID { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage ="End user is missing")]
        public int EndUserID { get; set; }

        [Required(ErrorMessage = "Company is missing")]
        public int CompanyId { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public virtual EndUser EndUser { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

        //TODO
        //forms
        // documents

    }
}
