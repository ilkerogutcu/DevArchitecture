﻿namespace WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Business.Handlers.Logs.Queries;
    using Core.Entities.Concrete;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// If controller methods will not be Authorize, [AllowAnonymous] is used.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : BaseApiController
    {
        /// <summary>
        /// List Logs
        /// </summary>
        /// <remarks>bla bla bla Logs</remarks>
        /// <return>Logs List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OperationClaim>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetLogDtoQuery());
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
    }
}