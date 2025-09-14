using CreditDeclaration.Models;
using CreditDeclaration.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditDeclaration.Controllers
{
    [ApiController] // Specifies that this is an API controller
    [Route("api/[controller]")] // Defines the route as 'api/'
    public class SourceInformationController : ControllerBase
    {
        private readonly ISourceInformationService _sourceService; // Service instance for business logic

        public SourceInformationController(ISourceInformationService sourceService)
        {
            _sourceService = sourceService; // Injecting the service via constructor
        }

        // Handles HTTP GET request to fetch all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activities = await _sourceService.GetAllSourcesAsync(); // Calls service to get all 
            return Ok(activities); // Returns 200 OK response with data
        }

        // Handles HTTP GET request to fetch a single by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string code)
        {
            try
            {
                var Source = await _sourceService.GetSourceAsync(code); // Calls service to fetcht by ID
                return Ok(Source); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP POST request to add a new 
        [HttpPost]
        public async Task<IActionResult> Add(SourceInformationCredit Source)
        {
            await _sourceService.CreateSourceAsync(Source); // Calls service to add a new 
            return Ok(Source); //CreatedAtAction(nameof(GetById), new { code = Source.Code }, Source);
            // Returns 201 Created response with location header pointing to the new
        }

        // Handles HTTP PUT request to update an existing 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, SourceInformationCredit Source)
        {
            try
            {
                await _sourceService.UpdateSourceAsync(id, Source); // Calls service to update 
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
                await _sourceService.DeleteSourceAsync(id); // Calls service to delete 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }
    }
}

