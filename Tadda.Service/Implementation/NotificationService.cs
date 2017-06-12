using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Data.Infrastructure;
using Tadda.Data.Repository;
using Tadda.Model.Entities;

namespace Tadda.Service.Implementation
{
    public class NotificationService : INotificationService
    {

        private readonly INotificationRepository _NotificationRepository;
        private readonly INotificationTemplateRepository _NotificationTemplateRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public NotificationService(INotificationRepository notRep, INotificationTemplateRepository notTempRep, IUnitOfWork uow)
        {
            this._NotificationRepository = notRep;
            this._NotificationTemplateRepository = notTempRep;
            this._UnitOfWork = uow;
        }

        public Notification CreateNotification(Notification notification)
        {
            _NotificationRepository.Add(notification);
            _UnitOfWork.Commit();

            return notification;
        }

        public IEnumerable<Notification> GetAllNotificationByOrder(int orderId)
        {
            return _NotificationRepository.GetAll().Where(x=>x.OrderId == orderId);
        }
        public IEnumerable<Notification> GetAllNotificationByEnduser(int enduserId)
        {
            return _NotificationRepository.GetAll().Where(x => x.EnduserId == enduserId);
        }

    }
}
