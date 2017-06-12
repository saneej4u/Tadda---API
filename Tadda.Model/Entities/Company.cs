using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadda.Model.Entities
{
    public class Company
    {
        public Company()
        {
            DateTimeCreated = DateTime.Now;
        }
        public int CompanyId { get; set; }
        public Guid CompanyUniqueId { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime RenewedOn { get; set; }
        public DateTime ExpireOn { get; set; }
        public DateTime DateTimeCreated { get; set; }

    }
}
