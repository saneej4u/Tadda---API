using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Data.Infrastructure;
using Tadda.Model.Entities;

namespace Tadda.Data.Repository
{

    class NotificationTemplateRepository : RepositoryBase<NotificationTemplate>, INotificationTemplateRepository
    {
        public NotificationTemplateRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface INotificationTemplateRepository : IRepository<NotificationTemplate>
    {

    }

}
