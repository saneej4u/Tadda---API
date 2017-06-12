using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Model.Entities;

namespace Tadda.Service
{
    public interface INotificationService
    {
        Notification CreateNotification(Notification notification);
        IEnumerable<Notification> GetAllNotificationByOrder(int orderId);

        IEnumerable<Notification> GetAllNotificationByEnduser(int enduserId);

    }
}
