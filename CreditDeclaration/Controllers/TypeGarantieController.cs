using CreditDeclaration.Models;
using CreditDeclaration.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditDeclaration.Controllers
{
    [ApiController] // Specifies that this is an API controller
    [Route("api/[controller]")] // Defines the route as 'api/'
    public class TypeGarantieController : ControllerBase
    {
        private readonly ITypeGarantieService _collateralService; // Service instance for business logic

        public TypeGarantieController(ITypeGarantieService collateralService)
        {
            _collateralService = collateralService; // Injecting the service via constructor
        }

        // Handles HTTP GET request to fetch all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var type = await _collateralService.GetAllCollateralsAsync(); // Calls service to get all 
            return Ok(type); // Returns 200 OK response with data
        }

        // Handles HTTP GET request to fetch a single by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string code)
        {
            try
            {
                var collateral = await _collateralService.GetCollateralAsync(code); // Calls service to fetcht by ID
                return Ok(collateral); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP POST request to add a new 
        [HttpPost]
        public async Task<IActionResult> Add(TypeGarantie collateral)
        {
            await _collateralService.CreateCollateralAsync(collateral); // Calls service to add a new 
            return Ok(collateral); //CreatedAtAction(nameof(GetById), new { code = bank.Code }, bank);
            // Returns 201 Created response with location header pointing to the new
        }

        // Handles HTTP PUT request to update an existing 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, TypeGarantie bank)
        {
            try
            {
                await _collateralService.UpdateCollateralAsync(id, bank); // Calls service to update 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP DELETE request to delete by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _collateralService.DeleteCollateralAsync(id); // Calls service to delete 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }
    }
}

