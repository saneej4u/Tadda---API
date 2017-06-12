using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadda.Model.Entities
{
    public class Address
    {
        public Address()
        {
            DateTimeCreated = DateTime.Now;
        }

        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string ApplicationUserID { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
