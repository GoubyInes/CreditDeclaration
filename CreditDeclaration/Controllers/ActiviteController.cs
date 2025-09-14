using CreditDeclaration.Models;
using CreditDeclaration.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditDeclaration.Controllers
{
    [ApiController] // Specifies that this is an API controller
    [Route("api/[controller]")] // Defines the route as 'api/'
    public class ActiviteController : ControllerBase
    {
        private readonly IActiviteService _activiteService; // Service instance for business logic

        public ActiviteController(IActiviteService activiteService)
        {
            _activiteService = activiteService; // Injecting the service via constructor
        }

        // Handles HTTP GET request to fetch all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activities = await _activiteService.GetAllActivitiesAsync(); // Calls service to get all 
            return Ok(activities); // Returns 200 OK response with data
        }

        // Handles HTTP GET request to fetch a single by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string code)
        {
            try
            {
                var activity = await _activiteService.GetActivityAsync(code); // Calls service to fetcht by ID
                return Ok(activity); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP POST request to add a new 
        [HttpPost]
        public async Task<IActionResult> Add(Activite activity)
        {
            await _activiteService.CreateActivityAsync(activity); // Calls service to add a new 
            return Ok(activity);
            // Returns 201 Created response with location header pointing to the new
        }

        // Handles HTTP PUT request to update an existing 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Activite activity)
        {
            try
            {
                await _activiteService.UpdateActivityAsync(id, activity); // Calls service to update 
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
                await _activiteService.DeleteActivityAsync(id); // Calls service to delete 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }
    }
}

