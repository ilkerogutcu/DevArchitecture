﻿namespace WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Business.Handlers.Languages.Commands;
    using Business.Handlers.Languages.Queries;
    using Core.Entities.Concrete;
    using Core.Entities.Dtos;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// If controller methods will not be Authorize, [AllowAnonymous] is used.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseApiController
    {
        /// <summary>
        /// LanguageLookUp with Code
        /// </summary>
        /// <remarks>bla bla bla Languages</remarks>
        /// <return>Languages List</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SelectionItem>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getlookupwithcode")]
        public async Task<IActionResult> GetLookupListWithCode()
        {
            var result = await Mediator.Send(new GetLanguagesLookUpWithCodeQuery());
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        /// <summary>
        /// LanguageLookUp
        /// </summary>
        /// <remarks>bla bla bla Languages</remarks>
        /// <return>Languages List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SelectionItem>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getlookup")]
        public async Task<IActionResult> GetLookupList()
        {
            var result = await Mediator.Send(new GetLanguagesLookUpQuery());
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        /// <summary>
        /// List languages
        /// </summary>
        /// <remarks>bla bla bla Languages</remarks>
        /// <return>Languages List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Language>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetLanguagesQuery());
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        /// <summary>
        /// It brings the details according to its id.
        /// </summary>
        /// <remarks>bla bla bla </remarks>
        /// <return>Language List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Language))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int languageId)
        {
            var result = await Mediator.Send(new GetLanguageQuery { Id = languageId });
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        /// <summary>
        /// Add Language.
        /// </summary>
        /// <param name="createLanguage"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguage)
        {
            var result = await Mediator.Send(createLanguage);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        /// <summary>
        /// Update Language.
        /// </summary>
        /// <param name="updateLanguage"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguage)
        {
            var result = await Mediator.Send(updateLanguage);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        /// <summary>
        /// Delete Language.
        /// </summary>
        /// <param name="deleteLanguage"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageCommand deleteLanguage)
        {
            var result = await Mediator.Send(deleteLanguage);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}