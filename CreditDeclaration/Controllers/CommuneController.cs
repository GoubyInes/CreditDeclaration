using CreditDeclaration.Models;
using CreditDeclaration.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditDeclaration.Controllers
{
    [ApiController] // Specifies that this is an API controller
    [Route("api/[controller]")] // Defines the route as 'api/'
    public class CommuneController : ControllerBase
    {
        private readonly ICommuneService _communeService; // Service instance for business logic

        public CommuneController(ICommuneService communeService)
        {
            _communeService = communeService; // Injecting the service via constructor
        }

        // Handles HTTP GET request to fetch all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var communes = await _communeService.GetAllCommunesAsync(); // Calls service to get all 
            return Ok(communes); // Returns 200 OK response with data
        }

        // Handles HTTP GET request to fetch a single by ID
        [HttpGet("{id}/{domaine}")]
        public async Task<IActionResult> GetById(string code, string domaine)
        {
            try
            {
                var commune = await _communeService.GetCommuneAsync(code, domaine); // Calls service to fetcht by ID
                return Ok(commune); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP POST request to add a new 
        [HttpPost]
        public async Task<IActionResult> Add(Commune com)
        {
            await _communeService.CreateCommuneAsync(com); // Calls service to add a new 
            return Ok(com);
            // Returns 201 Created response with location header pointing to the new
        }

        // Handles HTTP PUT request to update an existing 
        [HttpPut("{id}/{domaine}")]
        public async Task<IActionResult> Update(string id, string domaine, [FromBody] Commune commune)
        {
            try
            {
                await _communeService.UpdateCommuneAsync(id, domaine, commune); // Calls service to update 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP DELETE request to delete by ID
        [HttpDelete("{id}/{domaine}")]
        public async Task<IActionResult> Delete(string id, string domaine)
        {
            try
            {
                await _communeService.DeleteCommuneAsync(id, domaine); // Calls service to delete 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }
    }
}

