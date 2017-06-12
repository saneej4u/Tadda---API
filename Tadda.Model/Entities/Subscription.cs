using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadda.Model.Entities
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public string Name { get; set; }
        public int DurationInMonth { get; set; }
        public int NoOfusers { get; set; }
    }
}
