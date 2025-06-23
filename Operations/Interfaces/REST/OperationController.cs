using System.Data;
using Microsoft.AspNetCore.Mvc;
using RetoSem10.Operations.Domain.Models.Commands;
using RetoSem10.Operations.Domain.Models.Exceptions;
using RetoSem10.Operations.Domain.Models.Queries;
using RetoSem10.Operations.Domain.Services;
using RetoSem10.Operations.Interfaces.REST.Transform;

namespace RetoSem10.Operations.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController(
        IOperationQueryService operationQueryService,
        IOperationCommandService operationCommandService)
        : ControllerBase
    {
        
        private readonly IOperationQueryService _operationQueryService = operationQueryService ?? throw new ArgumentNullException(nameof(operationQueryService));
        private readonly IOperationCommandService _operationCommandService = operationCommandService ?? throw new ArgumentNullException(nameof(operationCommandService));
        
        
        // GET: api/operation
        public async Task<IActionResult> GetAsync()
        {
            var query = new GetAllOperationsQuery();
            var result = await _operationQueryService.Handle(query);

            if (!result.Any()) return NotFound("No books found.");

            var resources = result.Select(OperationResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(resources);
        }
        
        // POST: api/operation
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOperationCommand command)
        {
            if (command == null) return BadRequest("Invalid operation data.");

            try
            {
                await _operationCommandService.Handle(command);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (NotOperationsFoundExceptions exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        
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