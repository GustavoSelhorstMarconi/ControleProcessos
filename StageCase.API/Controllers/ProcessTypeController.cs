using Microsoft.AspNetCore.Mvc;
using StageCase.Application.Contracts;
using StageCase.Application.Dtos;

namespace StageCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessTypeController : ControllerBase
    {
        private readonly IProcessTypeService _processTypeService;

        public ProcessTypeController(IProcessTypeService processTypeService)
        {
            _processTypeService = processTypeService;
        }

        ///<summary>Add a new process type</summary>
        ///<remarks>Add a new process type based in a dto</remarks>
        ///<param name="processTypeDto">Process type model to create a process type</param>
        ///<response code="204">Return when is created a process type</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Add(ProcessTypeDto processTypeDto)
        {
            await _processTypeService.Add(processTypeDto);

            return NoContent();
        }

        ///<summary>Get all processes types</summary>
        ///<remarks>Get all processes types with processes</remarks>
        ///<returns>Return a list with all processes types</returns>
        ///<response code="200">Return when get processes</response>
        ///<response code="400">Wrong return</response>
        ///<response code="500">Internal error on server</response>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseDto<List<ProcessTypeDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Get()
        {
            ResponseDto<List<ProcessTypeDto>>? processTypes = await _processTypeService.Get();

            return Ok(processTypes);
        }

        ///<summary>Update a process type</summary>
        ///<remarks>Update a process type name</remarks>
        ///<param name="processTypeDto">Process type model to update</param>
        ///<response code="204">Return when updates a process type</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Update(ProcessTypeDto processTypeDto)
        {
            await _processTypeService.Update(processTypeDto);

            return NoContent();
        }

        ///<summary>Delete a process type</summary>
        ///<remarks>Delete a process type</remarks>
        ///<param name="idProcessType">Process type id to delete</param>
        ///<response code="200">Return when delete a process type successfully</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpDelete]
        [Route("{idProcessType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Delete(int idProcessType)
        {
            await _processTypeService.Delete(idProcessType);

            return NoContent();
        }
    }
}
