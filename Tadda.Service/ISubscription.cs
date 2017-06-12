using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Model.Entities;

namespace Tadda.Service
{
    public interface ISubscription
    {
        IEnumerable<Subscription> GetAllSubscriptions();
        Subscription GetAllSubscriptionById(int subscriptionId);
    }
}
