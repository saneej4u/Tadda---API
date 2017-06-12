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
    [RoutePrefix("api/tadda/order")]
    public class OrderController : BaseApiController
    {
        private IOrderService _IOrderService;

        public OrderController() { }

        public OrderController(IOrderService orderServ)
        {
            this._IOrderService = orderServ;
        }

        [Route("enduser/{enduserId}/all")]
        [HttpGet]
        public IHttpActionResult GetAllOrder(int enduserId)
        {
            try
            {
                var orders = _IOrderService.GetAllOrderByUser(enduserId);
                if (orders != null)
                {
                    return Ok(orders);
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
        public IHttpActionResult PostOrder([FromBody] Order order)
        {
            try
            {
                if (order != null)
                {
                    if (ModelState.IsValid)
                    {
                        var result = _IOrderService.CreateOrder(order);
                        return Created(Request.RequestUri + "/" + result.OrderID.ToString(), result);
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);

            }
            return BadRequest();
        }


        [HttpPost]
        [Route("line/create")]
        public IHttpActionResult PostOrderLines([FromBody] OrderLine orderLine)
        {
            try
            {
                if (orderLine != null)
                {
                    if (ModelState.IsValid)
                    {
                        var result = _IOrderService.CreateOrderLine(orderLine);
                        return Created(Request.RequestUri + "/" + result.OrderLineID.ToString(), result);
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);

            }
            return BadRequest();
        }

    }
}
