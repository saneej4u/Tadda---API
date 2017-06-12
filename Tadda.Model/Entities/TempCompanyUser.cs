using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadda.Model.Entities
{
    public class TempCompanyUser
    {
        public TempCompanyUser()
        {
            DateTimeCreated = DateTime.Now;
        }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyId { get; set; }
        public Guid CompanyUniqueId { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}
