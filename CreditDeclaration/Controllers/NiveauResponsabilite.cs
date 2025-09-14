using CreditDeclaration.Models;
using CreditDeclaration.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditDeclaration.Controllers
{
    [ApiController] // Specifies that this is an API controller
    [Route("api/[controller]")] // Defines the route as 'api/'
    public class NiveauResponsabiliteController : ControllerBase
    {
        private readonly INiveauResponsabiliteService _levelService; // Service instance for business logic

        public NiveauResponsabiliteController(INiveauResponsabiliteService levelService)
        {
            _levelService = levelService; // Injecting the service via constructor
        }

        // Handles HTTP GET request to fetch all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var levels = await _levelService.GetAllLevelsAsync(); // Calls service to get all 
            return Ok(levels); // Returns 200 OK response with data
        }

        // Handles HTTP GET request to fetch a single by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string code)
        {
            try
            {
                var level = await _levelService.GetLevelAsync(code); // Calls service to fetcht by ID
                return Ok(level); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP POST request to add a new 
        [HttpPost]
        public async Task<IActionResult> Add(NiveauResponsabilite level)
        {
            await _levelService.CreateLevelAsync(level); // Calls service to add a new 
            return Ok(level); //CreatedAtAction(nameof(GetById), new { code = level.Code }, level);
            // Returns 201 Created response with location header pointing to the new
        }

        // Handles HTTP PUT request to update an existing 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, NiveauResponsabilite level)
        {
            try
            {
                await _levelService.UpdateLevelAsync(id, level); // Calls service to update 
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
                await _levelService.DeleteLevelAsync(id); // Calls service to delete 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }
    }
}

