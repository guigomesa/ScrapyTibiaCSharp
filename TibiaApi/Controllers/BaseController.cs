using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TibiaApi.Comum.WebReturns;

namespace TibiaApi.Web.Controllers
{
    public abstract class BaseController : Controller
    {

        protected virtual ActionResult ReturnBasedServiceLayer(ModelBaseReturn returnModel)
        {
            switch (returnModel.Status)
            {
                case HttpStatusCode.Created:
                    return Created(returnModel.UrlCreated, returnModel.Model);
                case HttpStatusCode.NoContent:
                    return NoContent();
                case HttpStatusCode.OK:
                    return Ok(returnModel.Model);
                case HttpStatusCode.NotFound:
                    return NotFound(returnModel.Model);

                case HttpStatusCode.BadRequest:
                case HttpStatusCode.InternalServerError:
                    return BadRequest(new { Message = returnModel.Message, ErrorData = returnModel.Model });
            }

            throw new ArgumentException("Status Code no supported in return", nameof(returnModel));
        }
    }
}
