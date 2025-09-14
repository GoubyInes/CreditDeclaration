using CreditDeclaration.Models;
using CreditDeclaration.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditDeclaration.Controllers
{
    [ApiController] // Specifies that this is an API controller
    [Route("api/[controller]")] // Defines the route as 'api/'
    public class FonctionDirigeantController : ControllerBase
    {
        private readonly IFonctionDirigeantService _functionService; // Service instance for business logic

        public FonctionDirigeantController(IFonctionDirigeantService functionService)
        {
            _functionService = functionService; // Injecting the service via constructor
        }

        // Handles HTTP GET request to fetch all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var functions = await _functionService.GetAllFunctionsAsync(); // Calls service to get all 
            return Ok(functions); // Returns 200 OK response with data
        }

        // Handles HTTP GET request to fetch a single by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string code)
        {
            try
            {
                var function = await _functionService.GetFunctionAsync(code); // Calls service to fetcht by ID
                return Ok(function); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP POST request to add a new 
        [HttpPost]
        public async Task<IActionResult> Add(FonctionDirigeant function)
        {
            await _functionService.CreateFunctionAsync(function); // Calls service to add a new 
            return Ok(function); //CreatedAtAction(nameof(GetById), new { code = function.Code }, function);
            // Returns 201 Created response with location header pointing to the new
        }

        // Handles HTTP PUT request to update an existing 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, FonctionDirigeant function)
        {
            try
            {
                await _functionService.UpdateFunctionAsync(id, function); // Calls service to update 
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
                await _functionService.DeleteFunctionAsync(id); // Calls service to delete 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }
    }
}

