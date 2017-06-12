using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tadda.Model.Entities;
using Tadda.Service;
using Tadda.WebApi.Models;

namespace Tadda.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/tadda/enduser")]
    public class EndUserController : BaseApiController
    {
        private IEndUserService _IEndUserService;
        private IOrderService _IOrderService;

        public EndUserController(IEndUserService enduserService, IOrderService orderService)
        {
            this._IEndUserService = enduserService;
            this._IOrderService = orderService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IHttpActionResult EndUserLogin([FromBody] EndUserLoginModel model)
        {
            if (model == null) { return BadRequest(); }
            try
            {
                EndUser user = _IEndUserService.GetUser(model.Email);
                if (user != null)
                {
                    if (user.PassOne == model.Passcode1 && user.PassTwo == model.Passcode2
                        && user.PassThree == model.Passcode3 && user.PassFour == model.Passcode4)
                    {
                        return Ok(user);
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("register")]
        public IHttpActionResult EndUserRegister([FromBody] EndUserLoginModel model)
        {
            if (model == null) { return BadRequest(); }
            try
            {
                EndUser user = _IEndUserService.GetUser(model.Email);
                if (user != null)
                {
                    if (user.DateOfBirth.Equals(model.DateOfBirth))
                    {
                        user.PassOne = model.Passcode1;
                        user.PassTwo = model.Passcode2;
                        user.PassThree = model.Passcode3;
                        user.PassFour = model.Passcode4;
                        var result = _IEndUserService.UpdateEnduser(user);
                        return Ok(result);
                    }
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult PostEndUser([FromBody] EndUser EndUser)
        {
            try
            {
                if (EndUser != null)
                {
                    if (ModelState.IsValid)
                    {
                        var result = _IEndUserService.CreateEnduser(EndUser);
                        return Created(Request.RequestUri + "/" + result.EndUserId.ToString(), result);
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

        [Route("order/all")]
        [HttpGet]
        public IHttpActionResult GetAllOrder([FromBody] EndUserLoginModel model)
        {
            try
            {
                if (model == null) { return BadRequest(); }

                EndUser user = _IEndUserService.GetUser(model.Email);
                if (user != null)
                {
                    if (user.PassOne == model.Passcode1 && user.PassTwo == model.Passcode2
                       && user.PassThree == model.Passcode3 && user.PassFour == model.Passcode4)
                    {

                        var orders = _IOrderService.GetAllOrderByUser(user.EndUserId);
                        if (orders != null)
                        {
                            return Ok(orders);
                        }
                    }

                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        [Route("company/{companyId}")]
        [HttpGet]
        public IHttpActionResult GetAllEndUser([FromUri] int companyId)
        {
            try
            {
               IEnumerable<EndUser> users = _IEndUserService.GetAll(companyId);

                if (users != null && users.Any())
                {
                    return Ok(users);

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("isloggedin")]
        [HttpGet]
        public IHttpActionResult IsLoggedIn()
        {
            return Json(true);
        }

    }
}
