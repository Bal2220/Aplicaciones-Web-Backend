using Microsoft.AspNetCore.Mvc;
using RetoSem11.Management.Domain.Models.Commands;
using RetoSem11.Management.Domain.Models.Exceptions;
using RetoSem11.Management.Domain.Models.Queries;
using RetoSem11.Management.Domain.Services;
using RetoSem11.Management.Interfaces.REST.Transform;

namespace RetoSem11.Management.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OperationController(
        IOperationQueryService operationQueryService,
        IOperationCommandService operationCommandService)
        : ControllerBase
    {
        
        private readonly IOperationQueryService _operationQueryService = operationQueryService ?? throw new ArgumentNullException(nameof(operationQueryService));
        private readonly IOperationCommandService _operationCommandService = operationCommandService ?? throw new ArgumentNullException(nameof(operationCommandService));
        
        /// <summary>
        /// Get all operations
        /// </summary>
        // GET: api/operation
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var query = new GetAllOperationsQuery();
            var result = await _operationQueryService.Handle(query);

            if (!result.Any()) return NotFound("No books found.");

            var resources = result.Select(OperationResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(resources);
        }
        
        /// <summary>
        /// Add a operation
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/operation
        ///     {
        ///        "title": "Title between 3 and 100 characters",
        ///        "description": "Description with less than 250 characters",
        ///        "type": "Excavation OR Transport OR Maintenance",
        ///        "date": 2025-06-24T09:00:00",
        ///        "status": true OR false
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="407">The value are not expected</response>
        // POST: api/operation
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status417ExpectationFailed)]
        public async Task<IActionResult> Post([FromBody] CreateOperationCommand command)
        {
            if (command == null) return BadRequest("Invalid operation data.");

            try
            {
                await _operationCommandService.Handle(command);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (NotOperationFoundException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        
        /// <summary>
        /// Delete a operation through id
        /// </summary>
        // DELETE: api/operation/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid operation ID");

            try
            {
                var command = new DeleteOperationCommand(id);
                await _operationCommandService.Handle(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
    

