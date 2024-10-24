using Microsoft.AspNetCore.Mvc;
using StageCase.Application.Contracts;
using StageCase.Application.Dtos;

namespace StageCase.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;

        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }

        ///<summary>Add a new process</summary>
        ///<remarks>Add a new process based in a dto</remarks>
        ///<param name="processDto">Process model to create a process</param>
        ///<returns>Return process created</returns>
        ///<response code="200">Return when is created a process</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<ProcessDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Add(ProcessDto processDto)
        {
            ResponseDto<ProcessDto> process = await _processService.Add(processDto);

            return Ok(process);
        }

        ///<summary>Get all processes of a type</summary>
        ///<remarks>Get all processes of a types with subprocesses</remarks>
        ///<param name="idProcessType">Process type id to search all process of this type</param>
        ///<returns>Return a list with all processes</returns>
        ///<response code="200">Return when get processes</response>
        ///<response code="400">Wrong return</response>
        ///<response code="500">Internal error on server</response>
        [HttpGet]
        [Route("{idProcessType}")]
        [ProducesResponseType(typeof(ResponseDto<List<ProcessDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Get(int idProcessType)
        {
            ResponseDto<List<ProcessDto>>? processes = await _processService.Get(idProcessType);

            return Ok(processes);
        }


        ///<summary>Update a process</summary>
        ///<remarks>Update a process name and description</remarks>
        ///<param name="processDto">Process model to update a process</param>
        ///<returns>Return process updated</returns>
        ///<responses code="200">Return when updates a process</responses>
        ///<responses code="400">Wrong informations</responses>
        ///<responses code="500">Internal error on server</responses>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseDto<ProcessDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Update(ProcessDto processDto)
        {
            ResponseDto<ProcessDto> process = await _processService.Update(processDto);

            return Ok(process);
        }

        ///<summary>Delete a process</summary>
        ///<remarks>Delete a process</remarks>
        ///<param name="idProcess">Process id to delete this process</param>
        ///<response code="200">Return when delete a process successfully</response>
        ///<response code="400">Wrong informations</response>
        ///<response code="500">Internal error on server</response>
        [HttpDelete]
        [Route("{idProcess}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Delete(int idProcess)
        {
            await _processService.Delete(idProcess);

            return NoContent();
        }
    }
}
