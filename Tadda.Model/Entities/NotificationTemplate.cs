using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadda.Model.Entities
{
    public class NotificationTemplate
    {
        public int NotificationTemplateId { get; set; }
        public Guid CompanyUniqueId { get; set; }
        public String Name { get; set; }
        public string Message { get; set; }
    }
}
