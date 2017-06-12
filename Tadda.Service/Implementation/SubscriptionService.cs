using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Data.Repository;
using Tadda.Model.Entities;

namespace Tadda.Service.Implementation
{
    public class SubscriptionService : ISubscription
    {
        private readonly ISubscriptionRepository _SubscriptionRepository;
      
        public SubscriptionService(ISubscriptionRepository subRep)
        {
            this._SubscriptionRepository = subRep;
        }

        public Subscription GetAllSubscriptionById(int subscriptionId)
        {
            return _SubscriptionRepository.GetById(subscriptionId);
        }

        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            return _SubscriptionRepository.GetAll();
        }
    }
}
