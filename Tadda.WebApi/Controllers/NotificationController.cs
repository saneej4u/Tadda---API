using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tadda.Model.Entities;
using Tadda.Service;

namespace Tadda.WebApi.Controllers
{
    [RoutePrefix("api/tadda/notification")]
    public class NotificationController : BaseApiController
    {
        private INotificationService _NotificationService;
        public NotificationController()
        {

        }
        public NotificationController(INotificationService notificationService)
        {
            this._NotificationService = notificationService;
        }

        [Route("order/{orderId}/notifications")]
        [HttpGet]
        public IHttpActionResult GetAllNotificationByOrderId(int orderId)
        {
            try
            {
                var notifications = _NotificationService.GetAllNotificationByOrder(orderId).OrderByDescending(x=>x.NotificationId);

                if(notifications !=null)
                {
                    return Ok(notifications);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception)
            {
              return  InternalServerError();
            }
        }

        [Route("enduser/{enduserId}/notifications")]
        [HttpGet]
        public IHttpActionResult GetAllNotificationByEnduserId(int enduserId)
        {
            try
            {
                var notifications = _NotificationService.GetAllNotificationByEnduser(enduserId).OrderByDescending(x => x.NotificationId);

                if (notifications != null)
                {
                    return Ok(notifications);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateNotification([FromBody]Notification notification)
        {
            try
            {
                if (notification == null)
                {
                    return BadRequest();
                }
                var result = _NotificationService.CreateNotification(notification);
                return Created(Request.RequestUri + "/" + result.NotificationId.ToString(), result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
