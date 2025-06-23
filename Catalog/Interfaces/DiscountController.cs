using Microsoft.AspNetCore.Mvc;
using RetoSem9.Catalog.Domain.Models.Commands;
using RetoSem9.Catalog.Domain.Models.Queries;
using RetoSem9.Catalog.Domain.Services;

namespace RetoSem9.Catalog.Interfaces
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private IDiscountQueryServices _discountQueryServices;
        private IDiscountCommandServices _discountCommandService;
        public DiscountController(IDiscountQueryServices discountQueryService, IDiscountCommandServices discountCommandService)
        {
            _discountQueryServices = discountQueryService;
            _discountCommandService = discountCommandService;
        }
        
        // POST api/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDiscountCommand command)
        {
            await _discountCommandService.Handler(command);
            
            return Created();
        }
        
        // GET: api/catalog
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var query = new GetAllDiscount();
            var result = await _discountQueryServices.Handler(query);
            
            if (result.Count() == 0 )  return BadRequest();
            
            return Ok(result);
        }
        
        // GET: api/catalog/types
        [HttpGet("types")]
        public async Task<IActionResult> GetAllProductTypes()
        {
            var types = await _discountQueryServices.Handler(new GetAllProductsType());
            return Ok(types);
        }

        // GET: api/catalog/memberships
        [HttpGet("memberships")]
        public async Task<IActionResult> GetAllMembershipStatuses()
        {
            var statuses = await _discountQueryServices.Handler(new GetAllMembershipStatus());
            return Ok(statuses);
        }

    }
}