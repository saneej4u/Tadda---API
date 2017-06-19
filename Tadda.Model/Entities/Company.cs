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
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string BrandLogoUrl { get; set; }

    }
}
